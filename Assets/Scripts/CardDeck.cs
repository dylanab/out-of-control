using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public int deckSize = 10;
    public List<Card> discard = new List<Card>(); // Do we need this?
    public List<Card> cards = new List<Card>();
    public List<Card> hand = new List<Card>();

    #region Card Data
    [Header("Card Data")]
    public List<Card> cardData = new List<Card>();
    private Dictionary<int, int> cardCounts = new Dictionary<int, int>() {
        {0, 2},
        {1, 2},
        {2, 2},
        {3, 2},
        {4, 2},
        {5, 2},
    };
    #endregion Card Data

    // ----- Events -----
    public event System.Action deckShuffled;
    public event System.Action cardsChanged; // Alerts card UI that hand/deck/discard have changes 
    
    private const int HAND_SIZE = 5;

    private void Awake() 
    {
        // Add correct number of each card to deck at start of game
        foreach(Card c in cardData) 
        {
            int count = cardCounts[c.id];
            for (int i = 0; i < count; i++)
            {
                cards.Add(c);
            }
        }    
        Helpers.Shuffle<Card>(cards);

        // Alert listeners that cards changed after short delay
        // StartCoroutine(DelayedAlert(2));
    }

    private void Start() {
        GameManager.Instance.phaseChanged += OnPhaseChanged;
    }

    #region Public Interface
    public void GetNewHand(bool discardBloodLust = false) 
    {
        DiscardHand(discardBloodLust);
        StartCoroutine(DrawCardTimer(HAND_SIZE));
    }

    public void Discard(Card c) 
    {
        // TODO: Test this
        hand.Remove(c);
        discard.Add(c);

        if (this.cardsChanged != null)
            this.cardsChanged();
    }

    public void PrintCards(List<Card> cardsToPrint) 
    {
        string s = "";
        foreach(Card c in cardsToPrint) {
            s += c.id + ", ";
        }
        Debug.Log(s);
    }
    #endregion Public Interface


    #region Event handlers
    private void OnPhaseChanged(Phase newPhase, Phase previousPhase)
    {
        if (newPhase == Phase.Setup)
        {
            GetNewHand(previousPhase == Phase.Kill);
        }
    }
    #endregion  


    #region Private Helpers
    private Card drawCard() {
        Card nextCard = cards[0];
        cards.RemoveAt(0);

        // If we just drew the last card, shuffle discard into the deck
        if (cards.Count == 0) {
            foreach(Card c in discard) {
                cards.Add(c);
                Helpers.Shuffle<Card>(cards);
                discard = new List<Card>();
            }
        }

        return nextCard;
    }

    private IEnumerator DrawCardTimer(int draws) {
        while (draws > 0) {
            yield return new WaitForSeconds(0.5f);
            this.hand.Add(this.drawCard());
            draws--;

            // Alert Card display to show changes
            if (this.cardsChanged != null)
                this.cardsChanged();
            
            GameManager.Instance.DealingDone();
        }
    }

    private void DiscardHand(bool removeBloodlust) {
        List<Card> cardsToRemove = new List<Card>();
        foreach(Card c in hand) {
            if (c.name != "Bloodlust" || removeBloodlust)
            {
                discard.Add(c);
                cardsToRemove.Add(c);
            }
        }
        foreach(Card c in cardsToRemove)
        {
            hand.Remove(c);
        }

        // Alert Card display to show changes
        if (this.cardsChanged != null)
            this.cardsChanged();
    }

    private IEnumerator DelayedAlert(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (this.cardsChanged != null)
            this.cardsChanged();
    }
    #endregion Private Helpers
}



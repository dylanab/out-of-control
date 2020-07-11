using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public int deckSize = 10;
    public List<Card> discard = new List<Card>(); // Do we need this?
    public List<Card> cards = new List<Card>();
    public List<Card> hand = new List<Card>();

    // ----- Events -----
    public event System.Action deckShuffled;
    public event System.Action cardsChanged; // Alerts card UI that hand/deck/discard have changes 
    
    private const int HAND_SIZE = 5;

    #region Public Interface
    public void GetNewHand() {
        DiscardHand();
        StartCoroutine(DrawCardTimer(HAND_SIZE));
    }

    public void PrintCards(List<Card> cardsToPrint) {
        string s = "";
        foreach(Card c in cardsToPrint) {
            s += c.id + ", ";
        }
        Debug.Log(s);
    }
    #endregion Public Interface

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
        }
    }

    private void DiscardHand() {
        foreach(Card c in hand) {
            discard.Add(c);
        }
        hand = new List<Card>();
        // Alert Card display to show changes
        if (this.cardsChanged != null)
            this.cardsChanged();
    }
    #endregion Private Helpers
}

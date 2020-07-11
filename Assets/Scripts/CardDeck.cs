using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public List<Card> discard = new List<Card>(); // Do we need this?
    public List<Card> cards = new List<Card>();
    public List<Card> hand = new List<Card>();

    // ----- Events -----
    public event System.Action deckShuffled;
    public event System.Action cardsChanged; // Alerts card UI that hand/deck/discard have changes 
    
    private const int HAND_SIZE = 5;

    #region Public Interface
    public void GetNewHand() {
        Helpers.Shuffle<Card>(this.cards);
        List<Card> newHand = new List<Card>();
        for (int i = 0; i < HAND_SIZE; i++) {
            newHand.Add(cards[i]);
        }
        this.hand = newHand;
    }

    public void PrintCards(List<Card> cardsToPrint) {
        string s = "";
        foreach(Card c in cardsToPrint) {
            s += c.id + ", ";
        }
        Debug.Log(s);
    }
    #endregion Public Interface
}

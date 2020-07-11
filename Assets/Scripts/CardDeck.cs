using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : Singleton<CardDeck>
{
    public List<Card> discard = new List<Card>(); // Do we need this?
    public List<Card> cards = new List<Card>();
    public List<Card> hand = new List<Card>();
    
    private const int HAND_SIZE = 5;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.GetNewHand();
            printCards(this.hand);
        }
    }

    #region Public Interface
    public void GetNewHand() {
        this.shuffleCards();
        List<Card> newHand = new List<Card>();
        for (int i = 0; i < HAND_SIZE; i++) {
            newHand.Add(cards[i]);
        }
        this.hand = newHand;
    }
    #endregion Public Interface


    #region Private Helpers
    private void shuffleCards() {
        for (int t = 0; t < this.cards.Count; t++ )
        {
            Card tmp = this.cards[t];
            int r = Random.Range(t, this.cards.Count);
            this.cards[t] = this.cards[r];
            this.cards[r] = tmp;
        }
    }

    // Debug
    private void printCards(List<Card> cardsToPrint) {
        string s = "";
        foreach(Card c in cardsToPrint) {
            s += c.id + ", "; 
        }
        Debug.Log(s);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardArea : MonoBehaviour
{
    // Reference to data script
    public CardDeck deck; 

    [Header("Discard")]
    public Image discardImage;

    [Header("Deck")]
    public Text deckCount;
    public Image deckImage;
    [Space]

    [Header("Deck Sprites")]
    public Sprite empty;
    public Sprite one;
    public Sprite medium;
    public Sprite full;

    // Start is called before the first frame update
    void Start()
    {
        // Listen for events
        deck.cardsChanged += this.OnCardsChanged;
        deck.deckShuffled += this.OnDeckShuffle;
        GameManager.Instance.phaseChanged += this.OnPhaseChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ----- Event Handlers -----
    private void OnPhaseChange(Phase newPhase) {
        // TODO ?
    }
    private void OnDeckShuffle() 
    {
        // Play shuffle animation
    }

    private void OnCardsChanged() 
    {
        // Get new values
        int newDeckCount = deck.cards.Count;
        int newDiscardCount = deck.discard.Count;

        // Select a sprite
        this.deckImage.sprite = GetDeckSprite(newDeckCount);
        this.discardImage.sprite = GetDeckSprite(newDiscardCount);

        // Set counter
        this.deckCount.text = newDeckCount.ToString();
    }

    // TODO: Finalize these values
    private Sprite GetDeckSprite(int cardCount) {
        if (cardCount > 10) {
            return full;
        } else if (cardCount > 1) {
            return medium;
        } else if (cardCount == 1) {
            return one;
        } else {
            return empty;
        }
    }
}

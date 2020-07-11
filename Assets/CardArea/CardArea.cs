using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardArea : MonoBehaviour
{
    // Reference to data script
    public CardDeck deck; 

    [Header("Discard")]
    public Text discardCount;
    public Image discardImage;

    [Header("Deck")]
    public Text deckCount;
    public Image deckImage;
    [Space]

    [Header("Deck Sprites")]
    public Sprite empty;
    public Sprite medium;
    public Sprite full;

    // Overlay to prevent interaction
    public Image overlay; 

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
        // Disable overlay to allow interaction while on the play phase
        if (newPhase == Phase.Play) {
            overlay.enabled = false;
        } else {
            overlay.enabled = true;
        }
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

    }
}

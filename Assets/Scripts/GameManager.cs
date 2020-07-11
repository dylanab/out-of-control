using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase {
    Setup,
    Play,
    Resolution, // Needed?
    Kill,
}

public class GameManager : Singleton<GameManager>
{
    public int turn = 0;
    public CardDeck deck;
    public GuestList guests;

    public Phase phase = Phase.Setup;

    // ----- Events -----
    public System.Action<Phase> phaseChanged; // Called when... the phase changes
    public System.Action<Guest> guestKilled;
    public System.Action<TargetType> beginTargeting; // Called when the user clicks a card to begin targeting

    void Start()
    {
        
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            deck.GetNewHand();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1)) {
            phase = Phase.Play;
            this.phaseChanged(Phase.Play);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2)) {
            phase = Phase.Resolution;
            this.phaseChanged(Phase.Resolution);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3)) {
            phase = Phase.Setup;
            this.phaseChanged(Phase.Setup);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4)) {
            phase = Phase.Kill;
            this.phaseChanged(Phase.Kill);
        }
    }

    #region Public Interface
    public void BeginTargeting(Card c) {
        if (beginTargeting != null) {
            beginTargeting(c.targetType);
        }
    }

    // Called when the plater uses a card on a target
    public void UseCard(Card c, GameObject target = null) {
        // TODO: Based on the target type and the card, resolve the card
    }

    // Called when the player selects a target to kill
    public void KillGuest(Guest g) {
        // TODO: Take a Guest ref, and remove them from the game, incrementing suspicion, then checking win/conditions (inside suspicion func?)
    }

    // Called when the player ends the night without selecting a target
    public void EndNight() {
        // TODO: Add a bloodlust card to the deck, 
    }
    #endregion Public Interface


    #region Private Helpers
    private void initialize() {
        this.deck.GetNewHand();
    }
    #endregion Private Helpers
}

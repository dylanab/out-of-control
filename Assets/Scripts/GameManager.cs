using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase {
    Initial,
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

    public Phase phase = Phase.Initial;

    // ----- Events -----
    public System.Action<Phase> phaseChanged; // Called when... the phase changes
    public System.Action<Guest> guestKilled;
    public System.Action<TargetType> beginTargeting; // Called when the user clicks a card to begin targeting
    public System.Action endTargeting; // Called when the use has selected a target

    // Debug
    private bool targ =false;
    void Start()
    {
        StartCoroutine(InitialPhase(2f));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // AudioManager.Instance.PlayRandomQuip();
            // deck.GetNewHand();
            if (!targ)
                this.beginTargeting(TargetType.Guest);
            else
                this.endTargeting();
            targ = !targ;
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
        // Set Phase to Resolve to prevent input
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
    private void initialize() 
    {
        this.deck.GetNewHand();
    }

    // Called at start to wait a bit before setup while the game fades in
    private IEnumerator InitialPhase(float time)
    {
        yield return new WaitForSeconds(time);
        this.phase = Phase.Setup;
        if (this.phaseChanged != null)
            this.phaseChanged(Phase.Setup);
    }
    #endregion Private Helpers


    #region Giant Shameful Card Resolving Method
    private void ResolveCard(Card c, GameObject target) {
        // This is horrific and I would absolutely NEVER do this in production. But, y'know, game jam.
        switch(c.name) {
            case "Card 1":
                Debug.Log("Resolving Card 1");
                break;
            default:
                Debug.Log("This card does not exist: " + c.name);
                break;
        }
    }
    #endregion Giant Shameful Card Resolving Method
}

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

    // ----- Phase tracking -----
    public Phase phase = Phase.Initial;
    private bool dealingDone = false;
    private bool guestAssignmentDone = false;

    // ----- Events -----
    public System.Action<Phase, Phase> phaseChanged; // Called when... the phase changes
    public System.Action<Guest> guestKilled;
    public System.Action<TargetType> beginTargeting; // Called when the user clicks a card to begin targeting
    public System.Action endTargeting; // Called when the use has selected a target

    // Card reolution storage
    private Card currentCard;
    private int currentCardIndex = 99;
    private TargetType currentTargetType;
    private Guest guestTarget;
    private Room roomTarget;

    // Debug
    private bool targ =false;
    void Start()
    {
        StartCoroutine(InitialPhase(2f));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // AudioManager.Instance.PlayRandomQuip();
            deck.GetNewHand();
            // if (!targ)
            //     this.beginTargeting(TargetType.Guest);
            // else
            //     this.endTargeting();
            // targ = !targ;
        }
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            SetPhase(Phase.Setup);
        }
    }

    #region Public Interface
    public void BeginTargeting(Card c) {
        if (beginTargeting != null) {
            currentTargetType = c.targetType;
            beginTargeting(c.targetType);
        }
    }

    // Called when the plater uses a card on a target
    public void UseCard(Card c, int i) {
        // Set Phase to resolution to prevent input
        SetPhase(Phase.Resolution); // TEST THIS
        currentCard = c;
        currentCardIndex = i;
        if (c.targetType != TargetType.None) {
            BeginTargeting(c);
        } else {
            currentTargetType = TargetType.None;
            ResolveCard();
        }
    }

    // Called when the player selects a target to kill
    public void KillGuest(Guest g) {
        // TODO: Take a Guest ref, and remove them from the game, incrementing suspicion, then checking win/conditions (inside suspicion func?)
    }

    // Called when the player ends the night without selecting a target
    public void EndNight() {
        // TODO: Add a bloodlust card to the deck, 
    }

    // Called by a Room or Guest when targeted by a card
    public void SetTarget(GameObject obj) {
        if (currentTargetType == TargetType.Guest)
            this.guestTarget = obj.GetComponent<GuestPiece>().guest;
        else if (currentTargetType == TargetType.Room)
            this.roomTarget = obj.GetComponent<Room>();
        
        ResolveCard();
    }

    // These two functions are used to know when to set phase to play
    public void DealingDone() {
        if (guestAssignmentDone)
        {
            guestAssignmentDone = false;
            dealingDone = false;
            SetPhase(Phase.Play);
        } else {
            dealingDone = true;
        }
    }

    public void GuestAssignmentDone() { 
        if (dealingDone)
        {
            guestAssignmentDone = false;
            dealingDone = false;
            SetPhase(Phase.Play);
        } else {
            guestAssignmentDone = true;
        }
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
        SetPhase(Phase.Setup);
    }

    private void SetPhase(Phase newPhase)
    {
        if (this.phaseChanged != null)
            this.phaseChanged(newPhase, phase);

        this.phase = newPhase;
    }
    #endregion Private Helpers


    #region Giant Shameful Card Resolving Method
    private void ResolveCard() {
        this.endTargeting();
        Debug.Log("Resolving " + currentCard.name + " on target: " + (currentTargetType == TargetType.None ? "None" : guestTarget.name));
        // This is horrific and I would absolutely NEVER do this in production. But, y'know, game jam.
        switch(currentCard.name) {
            case "Card 1":
                break;
            default:
                Debug.Log("This card does not exist: " + currentCard.name);
                break;
        }

        // Remove card from hand
        deck.Discard(currentCardIndex);

        currentCard = null;
        currentTargetType = TargetType.None;
        guestTarget = null;
        roomTarget = null;
        SetPhase(Phase.Play);
    }
    #endregion Giant Shameful Card Resolving Method
}

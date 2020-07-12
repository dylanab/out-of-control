using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestPiece : MonoBehaviour
{
    public SpriteRenderer hoverHighlight;
    public SpriteRenderer highlight;
    public SpriteRenderer icon;

    public Guest guest;
    private bool targeting = false; // Set true while the player is looking for a card target
    private bool isTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.phaseChanged += OnPhaseChanged;
        GameManager.Instance.beginTargeting += OnTargetingBegin;
        GameManager.Instance.endTargeting += OnTargetingEnd;
    }

    private void Update() {
        // Guest was targeted by a card or murder button
        if (Input.GetMouseButtonUp(0) && isTarget) {
            GameManager.Instance.SetTarget(this.gameObject);
        }
    }

    private void OnMouseEnter() 
    {
        if (targeting) {
            highlight.enabled = true;
            isTarget = true;
        } else {
            hoverHighlight.enabled = true;
        }
        // TODO: Show Guest Details
    }

    private void OnMouseExit() 
    {
        highlight.enabled = false;
        hoverHighlight.enabled = false;
        isTarget = false;
        // TODO: Hide Guest Details
    }

    public void SetGuest(Guest g) 
    {
        guest = g;
        icon.sprite = g.icon;
    }

    private void OnTargetingBegin(TargetType type) 
    {
        if (type == TargetType.Guest && guest.name != "Adrian Van Hansing")
        {
            targeting = true;
        }
            
    }

    private void OnTargetingEnd()
    {
        targeting = false;
    }

    private void OnPhaseChanged(Phase newPhase, Phase prevPhase)
    {

    }
}

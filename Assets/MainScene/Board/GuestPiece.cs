using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestPiece : MonoBehaviour
{
    public SpriteRenderer highlight;
    public SpriteRenderer icon;

    private Guest guest;
    private bool targeting = false; // Set true while the player is looking for a card target

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.beginTargeting += OnTargetingBegin;
        GameManager.Instance.endTargeting += OnTargetingEnd;
    }

    private void OnMouseEnter() 
    {
        Debug.Log("Mouse In");
        if (targeting) {
            highlight.enabled = true;
        }
    }

    private void OnMouseExit() 
    {
        Debug.Log("Mouse Out");
        highlight.enabled = false;
    }

    public void SetGuest(Guest g) 
    {
        guest = g;
        icon.sprite = g.icon;
    }

    private void OnTargetingBegin(TargetType type) 
    {
        if (type == TargetType.Guest)
            targeting = true;
    }

    private void OnTargetingEnd()
    {
        targeting = false;
    }
}

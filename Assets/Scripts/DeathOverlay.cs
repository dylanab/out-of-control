using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathOverlay : MonoBehaviour
{
    public Image background;
    public Text countdown;
    public GuestPortrait portrait;
    public Animator animator;
    
    private Guest guest;
    
    private void OnEnable() 
    {
        guest = GameManager.Instance.victim;
        portrait.SetGuest(guest);
        countdown.text = GameManager.Instance.guests.GetLivingCount() + " guests remain.";
        animator.Play("intro");
    }

    private void KillAnim()
    {
        guest.isAlive = false;
        portrait.SetGuest(guest);
    }

    private void DoTheThing()
    {
        GameManager.Instance.SetGuestDead();
        animator.StopPlayback();
    }
}

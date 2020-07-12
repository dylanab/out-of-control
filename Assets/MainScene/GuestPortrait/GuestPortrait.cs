using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuestPortrait : MonoBehaviour
{
    public Image background;
    public Image frame;
    public Image character;
    public Image deathOverlay;
    public Image blood;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGuest(Guest g) {
        character.sprite = g.portrait;
        blood.enabled = !g.isAlive;
        deathOverlay.enabled = !g.isAlive;        
    }
}

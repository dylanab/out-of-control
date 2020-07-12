using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuestDetails : Singleton<GuestDetails>
{
    // ----- Chached Components -----
    public GuestPortrait portrait;
    public Animator animator;
    public Text name;
    public Text trait;
    public Text description;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGuest(Guest g) {
        portrait.SetGuest(g);
        name.text = g.name;
        trait.text = g.trait;
    }
}

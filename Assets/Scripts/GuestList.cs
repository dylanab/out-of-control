using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestList : MonoBehaviour
{
    public List<Trait> traits;
    public List<Guest> guests;

    public GuestList() {
        Initialize();
    }

    #region Public interface
    public void Initialize() {
        // Shuffle the trait list and guest list
        Helpers.Shuffle<Trait>(this.traits);
        Helpers.Shuffle<Guest>(this.guests);

        // Move through and assign a trait to each guest
        for (int i = 0; i < this.guests.Count; i++)
        {
            Guest g = this.guests[i];
            g.traits = new List<Trait>() { this.traits[i] };
        }

    }
    #endregion Public interface
}

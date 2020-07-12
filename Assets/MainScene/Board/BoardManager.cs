using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager> 
{
    public GuestList guestList;

    public Room[] Rooms;
    public List<GuestPiece> pieces;
    public Transform pieceCreationLocation; // Instatiate pieces here off camera

    private void Start() 
    {
        GameManager.Instance.phaseChanged += OnPhaseChange;
    }

    private void OnPhaseChange(Phase newPhase) 
    {
        if (newPhase == Phase.Setup) {
            for (int i = 0; i < guestList.guests.Count ; i++)
            {
                Guest g = guestList.guests[i];
                GuestPiece gp = guestList.pieces[g.name];

                // Pick a random room
            }
        }
    }
}

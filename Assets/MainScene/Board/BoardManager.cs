using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager> 
{
    public GuestList guestList;

    public Room[] rooms;
    public List<GuestPiece> pieces;
    public Transform pieceCreationLocation; // Instatiate pieces here off camera

    private void Start() 
    {
        GameManager.Instance.phaseChanged += OnPhaseChange;
    }

    // Used to get a room at random that has enough space for a guest
    public Room GetRandomAvailableRoom(Guest g, bool forceNew = false) 
    {
        Room randomRoom = rooms[Random.Range(0, rooms.Length)];
        while((forceNew && randomRoom == g.currentRoom) || randomRoom.guests.Count >= randomRoom.maxGuests) {
            randomRoom = rooms[Random.Range(0, rooms.Length)];
        }

        return randomRoom;
    }

    private void OnPhaseChange(Phase newPhase, Phase prevPhase) 
    {
        // Set all rooms 
        if (newPhase == Phase.Setup) {
            // Remove all guests from all rooms
            foreach(Room r in rooms)
            {
                r.Clear();
            }

            for (int i = 0; i < guestList.guests.Count ; i++)
            {
                Guest g = guestList.guests[i];
                if (g.isAlive)
                {
                    GuestPiece gp = guestList.pieces[g.name];

                    // Pick a random room
                    Room r = GetRandomAvailableRoom(g);
                    r.AddGuest(gp);
                }
            }

            GameManager.Instance.GuestAssignmentDone();
        }
    }
}

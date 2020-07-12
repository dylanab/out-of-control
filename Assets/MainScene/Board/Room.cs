using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool silent = false;
    public int maxGuests = 4;
    public List<Guest> guests;
    public List<Room> adjacentRooms;
    public Transform[] guestLocations;
    private bool[] locationTaken;

    // Start is called before the first frame update
    void Awake()
    {
        Clear();
    }

    private void Start() {
        // GameManager.Instance.phaseChanged += OnPhaseChange;
    }

    public void AddGuest(GuestPiece gp) 
    {
        guests.Add(gp.guest);
        gp.guest.currentRoom = gameObject.GetComponent<Room>();
        gp.transform.position = getNextFreeLocation().position;
    }

    public void RemoveGuest(Guest guestToRemove)
    {
        Guest rg = null;
        foreach (Guest g in guests)
        {
            if (g.name == guestToRemove.name)
            {
                rg = g;
                break;
            }
        }

        if (rg != null)
            guests.Remove(rg);
    }

    public void Clear()
    {
        silent = false;
        guests = new List<Guest>();
        locationTaken = new bool[guestLocations.Length];
        for (int i = 0; i < locationTaken.Length; i++)
        {
            locationTaken[i] = false;
        }
    }

    private Transform getNextFreeLocation() {
        int i = Random.Range(0, guestLocations.Length);
        while(locationTaken[i])
        {
            i = Random.Range(0, guestLocations.Length);
        }

        locationTaken[i] = true;
        return guestLocations[i];
    }

    private void OnPhaseChange(Phase newPhase, Phase old)
    {
        if (newPhase == Phase.Setup)
        {
            silent = false;
        }
    }
}

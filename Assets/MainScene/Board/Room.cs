using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
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

    public void AddGuest(GuestPiece gp) 
    {
        guests.Add(gp.guest);
        gp.transform.position = getNextFreeLocation().position;
    }

    public void Clear()
    {
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
}

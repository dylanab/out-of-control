using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int maxGuests = 4;
    public List<Guest> guests;
    public List<Room> adjacentRooms;
    public Transform[] guestLocations;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddGuest(Guest g) 
    {
        guests.Add(g);
        
    }
}

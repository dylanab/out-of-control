using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestList : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject piecePrefab;
    [Space]

    public List<Guest> guests;
    public Transform piecesLocation;

    private Dictionary<string, bool> deathList = new Dictionary<string, bool>();
    public Dictionary<string, GuestPiece> pieces = new Dictionary<string, GuestPiece>();

    void Awake() 
    {
        // Initialize deathList
        for (int i = 0; i < guests.Count; i++)
        {
            deathList[guests[i].name] = false;

            // Create game piece for this guest
            Vector3 spawn = piecesLocation.position + new Vector3(i, 0f, 0f);
            GuestPiece gp = Instantiate(piecePrefab, spawn, Quaternion.identity).GetComponent<GuestPiece>();
            gp.SetGuest(guests[i]);
            pieces[guests[i].name] = gp;
        }
    }

    private void Start() 
    {
        GameManager.Instance.guestKilled += OnGuestKilled;
    }
    
    #region Public interface
    public bool IsDead(Guest g) 
    {
        return deathList[g.name];
    }

    public int GetTotalSuspicion() {
        int totalSuspicion = 0;
        
        for (int i = 0; i < guests.Count; i++)
        {
            if(guests[i].isAlive) {
                totalSuspicion += guests[i].suspicion;
            }
        }

        return totalSuspicion;
    }

    public int GetGuestIndexByName(string targetName)
    {
        foreach(Guest g in guests)
        {
            if(g.name == targetName)
            {
                return guests.IndexOf(g);
            }
        }

        return -1;
    }
    #endregion Public interface

    private void OnGuestKilled(Guest victim) {
        foreach(Guest g in guests)
        {
            if (g.name == victim.name)
            {
                g.isAlive = false;
                GuestPiece gp = pieces[g.name];
                gp.guest.currentRoom.RemoveGuest(g);
                gp.transform.position = piecesLocation.position;
            }
        }
    }

    private void OnPhaseChanged(Phase newPhase, Phase oldPhase)
    {
        if (newPhase == Phase.Setup)
        {
            foreach(Guest g in guests)
            {
                g.status = Status.None;
            }
        }
    }

    public int GetLivingCount()
    {
        int l = 0;
        foreach(Guest g in guests)
        {
            if (g.isAlive)
            {
                l++;
            }
        }

        return l - 1;
    }
}

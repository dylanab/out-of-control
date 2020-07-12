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
    #endregion Public interface

    private void OnGuestKilled(Guest g) {
        deathList[g.name] = true;
    }
}

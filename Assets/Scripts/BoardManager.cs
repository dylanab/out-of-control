using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    private static BoardManager _instance = null;

    public Guest[] Guests;

    public Room[] Rooms;

    public static BoardManager Instance {
        get { return _instance; }
    }

    public void DisperseGuests() {

    } 

    public void GenerateRooms() {

    }

    private void Awake() {
        if(_instance != null && _instance != this) {
            GameObject.Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }
}

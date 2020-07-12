using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Guest {
    // Immutable guest Info
    public int id;
    public string name;
    public Sprite portrait;
    public Sprite icon;

    // Gameplay data
    public Room currentRoom;
    public bool isAlive = true;
    public int suspicion = 0;
    
    public void adjustSuspicion(int amount) {
        suspicion = suspicion + amount; // Use a negative amount to subtract
    }

    public void Kill() {
        this.isAlive = false;
    }
}
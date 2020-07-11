using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Guest {
    public int id;
    public string name;
    public bool isAlive = true;
    public int suspicion = 0;
    public List<Trait> traits = new List<Trait>();
    public Room currentRoom;
    
    public void adjustSuspicion(int amount) {
        suspicion = suspicion + amount; // Use a negative amount to subtract
    }

    public void Kill() {
        this.isAlive = false;
    }
}
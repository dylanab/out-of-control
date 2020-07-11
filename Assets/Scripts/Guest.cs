public struct Guest {
    public int id;
    public string name;
    public bool isAlive;
    public int suspicion;
    public Trait[] traits;
    //TODO: add reference to a room or a room id int, not sure which makes the most sense
    
    public void IncreaseSuspicion() {
        if(suspicion < maxSuspicion) { suspicion++; }
    }

    public void DecreaseSuspicion() {
        if(suspicion > 0) { suspicion--; }
    }
}

public struct Trait {
    public int id;
    public string name;
    public string description;
}
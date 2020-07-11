using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public TargetType targetType;
}

public enum TargetType {
    Guest,
    Room,
    None,
}

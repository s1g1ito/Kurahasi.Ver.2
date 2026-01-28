using UnityEngine;

public enum OreType 
{ 
    None, 
    Iron, 
    Gold, 
    Diamond, 
    Emerald, 
    Coal, 
    Copper 
}

[System.Serializable]
public class OreSlot
{
    public OreType type;
    public int amount;
}

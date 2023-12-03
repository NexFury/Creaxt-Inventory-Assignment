using UnityEngine;

public enum TypeOfItem
{
    Consumable, Equipment, Default
}

public abstract class Item : ScriptableObject 
{
    public Sprite objectImage;
    public float weight;
    [TextArea(15,20)]
    public string description;
    public TypeOfItem itemType;
}

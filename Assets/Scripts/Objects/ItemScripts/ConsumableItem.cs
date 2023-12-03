using UnityEngine;

[CreateAssetMenu(fileName = "ConsumableItem", menuName = "Creaxt Inventory Assignment/ConumableItem", order = 0)]
public class ConsumableItem : Item
{
    private void Awake() 
    {
        itemType = TypeOfItem.Consumable;
    }
}

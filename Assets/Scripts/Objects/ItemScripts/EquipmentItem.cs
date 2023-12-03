using UnityEngine;

[CreateAssetMenu(fileName = "EquipmentItem", menuName = "Creaxt Inventory Assignment/EquipmentItem", order = 0)]
public class EquipmentItem : Item
{
    private void Awake() 
    {
        itemType = TypeOfItem.Equipment;
    }
}

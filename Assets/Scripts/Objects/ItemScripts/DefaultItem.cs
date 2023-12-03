using UnityEngine;

[CreateAssetMenu(fileName = "DefaultItem", menuName = "Creaxt Inventory Assignment/DefaultItem", order = 0)]
public class DefaultItem : Item
{
    private void Awake() 
    {
        itemType = TypeOfItem.Default;
    }
}

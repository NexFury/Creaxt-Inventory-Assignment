using UnityEngine;
using com.Creaxt.Inventory;
using TMPro;

namespace com.Creaxt.Shop
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private InventoryManager inventoryManager;
        [SerializeField] private TMP_Text notificationText;
        private const int objectAmount = 1;
        private float time;

        //On-Click Event
        public void BuyItem(Item shopItem)
        {
            //Adds item to inventory
            bool hasItem = false;
            for (int i = 0; i < inventoryManager.slots.Length; i++)
            {
                if(shopItem.objectImage == inventoryManager.slots[i].slotImage.sprite)
                {
                    if(shopItem.itemType == TypeOfItem.Consumable && inventoryManager.slots[i].objectCount < 99)
                    {
                        inventoryManager.slots[i].AddAmount(objectAmount);
                        hasItem = true;
                    }
                    NotificationText(Color.blue, $"{shopItem.name} has been added to the inventory");
                    break;
                }
            }
            if(!hasItem)
            {
                //Add new item
                for (int i = 0; i < inventoryManager.slots.Length; i++)
                {
                    if(i == inventoryManager.slots.Length - 1 && inventoryManager.slots[i].item != null)
                    {
                        NotificationText(Color.red, "No more vacant slots remaining in the inventory");
                        break;
                    }
                    else if(inventoryManager.slots[i].item == null)
                    {
                        inventoryManager.slots[i].removeButton.interactable = true;
                        inventoryManager.slots[i].slotImage.enabled = true;
                        inventoryManager.slots[i].AddAmount(objectAmount);
                        if(shopItem.itemType == TypeOfItem.Consumable)
                        {
                            inventoryManager.slots[i].countText.enabled = true;
                        }
                        inventoryManager.slots[i].slotImage.sprite = shopItem.objectImage;
                        inventoryManager.slots[i].item = shopItem;
                        break;
                    }

                }
            }
        }

        private void NotificationText(Color color, string notification)
        {
            time = 3f;
            string message = "<color=#" + ColorUtility.ToHtmlStringRGBA(color) + ">" + notification + "</color>";
            notificationText.text = message;
        }

        private void Update() 
        {
            time -= Time.deltaTime;
            if(time <= 0)
                notificationText.text = string.Empty;
        }
    }
}

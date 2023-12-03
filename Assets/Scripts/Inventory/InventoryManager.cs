using System;
using com.Creaxt.SaveSystem;
using UnityEngine;

namespace com.Creaxt.Inventory
{
    public class InventoryManager : MonoBehaviour, IDataPersistence
    {
        [SerializeField] private Transform content;
        public InventorySlot[] slots;

        // Start is called before the first frame update
        void Start()
        {
            GetSlots();
        }

        private void GetSlots()
        {
            slots = content.GetComponentsInChildren<InventorySlot>();
        }

        public void LoadData(GameData gameData)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].slotImage.sprite = gameData.itemImage[i];
                slots[i].objectCount = gameData.itemCount[i];
                slots[i].item = gameData.itemType[i];
                if(slots[i].item != null)
                {
                    slots[i].removeButton.interactable = true;
                    slots[i].slotImage.enabled = true;
                    if(slots[i].item.itemType == TypeOfItem.Consumable)
                    {
                        slots[i].AddAmount(0);
                        slots[i].countText.enabled = true;
                    }
                }
            }
        }

        public void SaveData(ref GameData gameData)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                gameData.itemImage[i] = slots[i].slotImage.sprite;
                gameData.itemCount[i] = slots[i].objectCount;
                gameData.itemType[i] = slots[i].item;
            }
        }
    }
}

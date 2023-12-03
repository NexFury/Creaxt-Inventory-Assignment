using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.Creaxt.Inventory
{
    public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image slotImage;
        public Button removeButton;
        public TMP_Text countText;
        public int objectCount;

        [HideInInspector] public Item item;

        public static event Action<bool, string, string, string> OnHoverSlot = delegate { };
        public void AddAmount(int value)
        {
            objectCount += value;
            UpdateTextValue();
        }

        private void UpdateTextValue()
        {
            countText.text = objectCount.ToString();
        }

        //On-Click Event
        public void RemoveObject()
        {
            OnHoverSlot?.Invoke(false, string.Empty, string.Empty, string.Empty);
            removeButton.interactable = false;
            objectCount = 0;
            countText.text = string.Empty;
            slotImage.sprite = null;
            slotImage.enabled = false;
            countText.enabled = false;
            item = null;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(item == null) return;
            float newWeight = item.weight * objectCount;
            OnHoverSlot?.Invoke(true, item.name, newWeight.ToString(), item.description);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(item == null) return;
            OnHoverSlot?.Invoke(false, string.Empty, string.Empty, string.Empty);
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace com.Creaxt.Inventory
{
    public class InventoryHover : MonoBehaviour
    {
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text itemWeight;
        [SerializeField] private TMP_Text itemDescription;
        public const float x_Offset = 250f;

        private void OnEnable() 
        {
            InventorySlot.OnHoverSlot += ShowDetails;
        }

        private void OnDisable() 
        {
            InventorySlot.OnHoverSlot -= ShowDetails;
        }

        private void Awake() 
        {
            foreach (Transform item in transform)
            {
                item.GetComponent<TMP_Text>().enabled = false;
            }
            GetComponent<Image>().enabled = false;

        }

        private void ShowDetails(bool toggle, string name, string weight, string description)
        {
            foreach (Transform item in transform)
            {
                item.GetComponent<TMP_Text>().enabled = toggle;
            }
            itemName.text = "Item Name: " + name;
            itemWeight.text = "Item Weight: " + weight;
            itemDescription.text = "Item Description: " + description;
            GetComponent<Image>().enabled = toggle;
            transform.position = Input.mousePosition + new Vector3(x_Offset,0f,0f);
        }
    }
}

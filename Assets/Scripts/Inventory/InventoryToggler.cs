using UnityEngine;

namespace com.Creaxt.Inventory
{
    public class InventoryToggler : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryScrollView;
        private bool inventoryToggle;

        private void Awake() 
        {
            GetComponent<InputManager>().openInventory += OpenInventory;
        }

        // Start is called before the first frame update
        void Start()
        {
            inventoryToggle = inventoryScrollView.activeSelf;
        }

        public void OpenInventory()
        {
            inventoryToggle = !inventoryToggle;
            inventoryScrollView.SetActive(inventoryToggle);
        }
    }
}

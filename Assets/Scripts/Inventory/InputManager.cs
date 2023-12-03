using System;
using UnityEngine;

namespace com.Creaxt.Inventory
{
    public class InputManager : MonoBehaviour
    {
        public event Action openInventory = delegate { };
        public bool OpenInventory { get; private set; }

        // Update is called once per frame
        void Update()
        {
            OpenInventory = Input.GetKeyDown(KeyCode.E);
            if(OpenInventory)
            {
                openInventory();
            }
        }
    }
}

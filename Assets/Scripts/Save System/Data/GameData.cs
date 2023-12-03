using UnityEngine;

namespace com.Creaxt.SaveSystem
{
    [System.Serializable]
    public class GameData
    {
        public Sprite[] itemImage;
        public int[] itemCount;
        public Item[] itemType;

        public GameData()
        {
            this.itemImage = new Sprite[65];
            this.itemCount = new int[65];
            this.itemType = new Item[65];
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace com.Creaxt.SaveSystem
{
    public class DataPersistenceManager : MonoBehaviour
    {
        [Header("File Storage Config")]
        [SerializeField] private string fileName;

        private GameData gameData;
        private List<IDataPersistence> dataPersistenceObjects;
        public static DataPersistenceManager instance { get; private set; }
        private FileDataHandler dataHandler;

        private void Awake() 
        {
            if(instance != null)
            {
                Debug.LogError("Found more than one Data persistence manager in the scene");
            }
            instance = this;
        }

        private void Start() 
        {
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            this.dataPersistenceObjects = FindAllDataPersistenceObjects();
            LoadGame();
        }

        public void NewGame()
        {
            this.gameData = new GameData();
        }

        public void LoadGame()
        {
            //Load any saved data from the file using the data handler
            this.gameData = dataHandler.Load();

            //If no data to load, initialize a new game
            if(this.gameData == null)
            {
                Debug.Log("No data was found. Initializing the data to default");
                NewGame();
            }
            //TODO - Push the loaded data to all other scripts that need it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(gameData);
            }
        }

        public void SaveGame()
        {
            //TODO - Pass the data to other scripts so they can update it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.SaveData(ref gameData);
            }

            //Save that data to a file using the file data handler
            dataHandler.Save(gameData);
        }

        private void OnApplicationQuit() 
        {
            SaveGame();
        }

        private List<IDataPersistence> FindAllDataPersistenceObjects()
        {
            IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

            return new List<IDataPersistence>(dataPersistenceObjects);
        }
    }
}
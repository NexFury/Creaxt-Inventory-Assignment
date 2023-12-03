using UnityEngine;
using System;
using System.IO;

namespace com.Creaxt.SaveSystem
{
    public class FileDataHandler
    {
        private string dataDirPath = string.Empty;
        private string dataFileName = string.Empty;

        public FileDataHandler(string dataDirPath, string dataFileName)
        {
            this.dataDirPath = dataDirPath;
            this.dataFileName = dataFileName;
        }

        public GameData Load()
        {
            //Use Path.Combine to account for different OS's having seperate file seperators
            string fullpath = Path.Combine(dataDirPath, dataFileName);
            GameData loadedData = null;
            if(File.Exists(fullpath))
            {
                try
                {
                    //Load the serialized data from the file
                    string dataToLoad = string.Empty;
                    using(FileStream stream = new FileStream(fullpath, FileMode.Open))
                    {
                        using(StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }

                    //Deserialize the data from Json back into the C# script
                    loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
                }
                catch(Exception e)
                {
                    Debug.LogError("Error occured when trying to load data from the file: " + fullpath + "\n" + e);

                }
            }
            return loadedData;
        }

        public void Save(GameData gameData)
        {
            //Use Path.Combine to account for different OS's having seperate file seperators
            string fullpath = Path.Combine(dataDirPath, dataFileName);
            try
            {
                //Create the directory the file will be written to if it doesn't already exist
                Directory.CreateDirectory(Path.GetDirectoryName(fullpath));

                //Serialize the C# game data object into JSON
                string dataToStore = JsonUtility.ToJson(gameData, true);

                //Write the serialized data to a file
                using(FileStream stream = new FileStream(fullpath, FileMode.Create))
                {
                    using(StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(dataToStore);
                    }
                }
            }
            catch(Exception e)
            {
                Debug.LogError("Error occured when trying to save data to file: " + fullpath + "\n" + e);
            }
        }
    }
}

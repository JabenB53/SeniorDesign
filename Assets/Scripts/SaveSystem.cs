using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveProgress(int level)
    {
        GameData data = new GameData(level); // create a GameData object to store the level number

        BinaryFormatter formatter = new BinaryFormatter(); // this will serialize the data
        string filePath = Application.persistentDataPath + "/data.data"; // create a file at this location
        FileStream stream = new FileStream(filePath, FileMode.Create); // open the file stream for creating a file

        formatter.Serialize(stream, data); // write the highest level they've cleared to the file - serialized
        stream.Close();
    }

    public static int LoadProgress()
    {
        string filePath = Application.persistentDataPath + "/data.data"; // find a file at this location
        if(File.Exists(filePath))
        {
            BinaryFormatter formatter = new BinaryFormatter(); // this will serialize the data
            FileStream stream = new FileStream(filePath, FileMode.Open); // open the file stream for creating a file
            GameData data = new GameData(0); // create a GameData object to store the level number

            data = formatter.Deserialize(stream) as GameData; // grab the data as a GameData object
            stream.Close();
            return data.level; // return the level number
        }
        else
        {
            Debug.LogError("Save file not found at " + filePath); //if there is no save data
            return 0; // they have to start at the beginning
        }
    }

    public static void DeleteProgress()
    {
        string filePath = Application.persistentDataPath + "/data.data"; // find a file at this location
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        else
        {
            Debug.LogError("Save file not found at " + filePath); //if there is no save data
        }
    }
}
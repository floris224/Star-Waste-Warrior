using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public static void SaveData(Data data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/roelhoudvanmannen.lol";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveLoadData sl = new SaveLoadData(data);
        formatter.Serialize(stream, sl);
        stream.Close();
        Debug.Log("Game opgeslagen in " + path);
    }

    public static SaveLoadData LoadData()
    {
        string path = Application.persistentDataPath + "/roelhoudvanmannen.lol";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveLoadData data = formatter.Deserialize(stream) as SaveLoadData;
            stream.Close();
            Debug.Log("Data opgehaald uit " + path);
            return data;
        }
        else
        {
            Debug.LogError("SaveData niet gevonden in " + path);
            return null;
        }


    }
}

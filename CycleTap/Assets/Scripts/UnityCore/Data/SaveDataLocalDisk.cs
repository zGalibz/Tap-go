
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UnityCore
{
    namespace Data
    {
public static class SaveDataLocalDisk
        {
    public static void DataSave(DataManagement dataManagement)
    {
        BinaryFormatter Bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.gamoverse";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataController Data = new DataController(dataManagement);

        Bf.Serialize(stream, Data);
        stream.Close();

    }

    public static DataController LoadData()
      {
        string path = Application.persistentDataPath + "/data.gamoverse";
        if (File.Exists(path))
        {
            BinaryFormatter Bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataController Data = Bf.Deserialize(stream) as DataController;
            stream.Close();

            return Data;
        }
        else
        {
            Debug.LogError("Save file not found");
            return null;
        }
       }
      }
    }
}
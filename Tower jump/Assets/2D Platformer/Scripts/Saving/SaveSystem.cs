using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveData(ScoreManager scoreManager)
    {

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/score.binary";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData data = new SaveData(scoreManager);
        formatter.Serialize(stream, data);
        stream.Close(); 

    }

}

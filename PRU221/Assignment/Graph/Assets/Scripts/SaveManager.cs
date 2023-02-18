using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public string directory = "/SaveData/";
    public string fileName = "saveData.txt";

    public void Save(SaveData data)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        FileInfo fi = new FileInfo(dir + fileName);
        using (TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.Truncate)))
        {
            foreach (var moverData in data.Characters)
            {
                // Serialize to json
                var jsonData = JsonUtility.ToJson(moverData);

                txtWriter.WriteLine(jsonData);
            }
        }
    }

    public SaveData Load()
    {
        // Retrieve json data from storage of your choice
        string fullPath = Application.persistentDataPath + directory + fileName;
        SaveData saveData = new SaveData();
        saveData.Characters = new List<MoverData>();

        using (StreamReader sr = new StreamReader(fullPath))
        {
            while (sr.Peek() >= 0)
            {
                var jsonData = sr.ReadLine();
                MoverData moverData = JsonUtility.FromJson<MoverData>(jsonData);
                saveData.Characters.Add(moverData);
            }
        }

        return saveData;
    }

}


using System;
using Newtonsoft.Json;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Windows;
using File = System.IO.File;

namespace Managers
{
    public class StaticManager:MonoBehaviour
    {
        public static StaticManager Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        /*public T ReadData<T>() 
        {
            string json=File.ReadAllText(Application.persistentDataPath + "/" + typeof(T).Name + ".json");
            T data = JsonUtility.FromJson<T>(json);
            return data;
        }
        
        public void SaveData<T>(T data) 
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(Application.persistentDataPath + "/" + typeof(T).Name + ".json", json);
        }*/
        
        public static JSONNode LoadJson(string file)
        {
            return JSON.Parse(File.ReadAllText(Application.streamingAssetsPath+"/JsonData/"+file+".json", System.Text.Encoding.UTF8));
        }
    }
}
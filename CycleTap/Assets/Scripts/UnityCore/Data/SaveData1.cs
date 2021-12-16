using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore
{   namespace Data
    {
      
        public class SaveData1 : MonoBehaviour
        {
            private DataManagement dataManagement;
            public void SaveData()
            {
                Debug.Log("SAVED");
                SaveDataLocalDisk.DataSave(dataManagement);
            }
            public void LoadData()
            {
                Debug.Log("LOADED");
                DataController data = SaveDataLocalDisk.LoadData();
                DataManagement.Score = data.Score;
                DataManagement.HighScore = data.HighScore;
                DataManagement.Coin = data.Coin;
            }
        }
    }
}

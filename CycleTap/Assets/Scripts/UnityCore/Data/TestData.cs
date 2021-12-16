
using UnityEngine;

namespace UnityCore
{
    namespace Data
    {
        public class TestData : MonoBehaviour
        {
            #region Unity Functions
#if UNITY_EDITOR
            
            public SaveData1 SaveData;
            public DataManagement DataManagement;
            private void Awake()
             {
                DataManagement = FindObjectOfType<DataManagement>();
                SaveData = FindObjectOfType<SaveData1>();
                SaveData.LoadData();
            }
            private void Update()
            {
                if (Input.GetKeyUp(KeyCode.R))
                {
                    TestAddScore(17);
                    Log();
                   
                    SaveData.SaveData();
                    
                    
                }
                if (Input.GetKeyUp(KeyCode.T))
                {
                    TestAddScore(-14);
                    Log();
                    
                    SaveData.SaveData();
                    

                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    TestresetScore();
                    Log();

                    SaveData.SaveData();


                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    //DataManagement.CoinController(1);
                    Log();

                    SaveData.SaveData();


                }
            }
#endif
            #endregion

            #region Private Functions
            private void TestAddScore(int _delta)
            {
                DataManagement.Score += _delta;
            }
            private void TestresetScore()
            {
                DataManagement.Score = 0;
            }

            private void Log()
            {
               Debug.Log("[Test Data] : Score :" +DataManagement.Score+ "|||" +"HighScore :" +DataManagement.HighScore +" ||| Coin :"+DataManagement.Coin);
            }
            #endregion
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore
{
    namespace Data
    {

        public  class DataManagement : MonoBehaviour
        {
            #region All Datas
            public static  int Score;
            public static int HighScore;
            public static int Coin;
            public bool DatamanGamIns = false;
            #endregion

            #region Score Management

            #region Unity Functions
            private void Start()
            {
              
                
            }
             
            private void Update()
            {  if (DatamanGamIns)
                {
                    Coin = GameController.instance.TotalCoins;
                }
               
                if (Score > HighScore)
                {
                    HighScore = Score;
                }
               // Debug.Log(Coin + "coins");
            }
            #endregion


            #endregion
          /* 
            public void CoinController(int _coin)
            {
                Coin += _coin;
            }
            */
        }
   }
}

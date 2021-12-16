using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityCore
{ 
    namespace Data
    {
        [System.Serializable]
        public  class DataController
        {
            #region All Datas
            public int Score;
            public int HighScore;
            public int Coin;

            public DataController(DataManagement dataManagement)
            {
                Score = DataManagement.Score;
                HighScore = DataManagement.HighScore;
                Coin = DataManagement.Coin; 
            }
                

            #endregion


        } 
    }
}

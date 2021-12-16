using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCore.Data;
using UnityEngine.UI;
using TMPro;

public class OnscreenUImenu : MonoBehaviour
{
    public TMPro.TMP_Text TextTotalCoin;

    public SaveData1 savedata;
    public DataManagement DataManagement;
   
    // Start is called before the first frame update
    void Start()
    {
        savedata = FindObjectOfType<SaveData1>();
       DataManagement = FindObjectOfType<DataManagement>();
        savedata.LoadData();
       TextTotalCoin.text = DataManagement.Coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coinss : MonoBehaviour
{
    public Text TextToalCoin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextToalCoin.text = GameController.instance.Coin.ToString();
    }
}

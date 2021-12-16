using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTrigger : MonoBehaviour
{   public bool ShieldEnable = false;
     private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag.Equals("Player"))
        {
           ShieldEnable = true;
        }


    }
}

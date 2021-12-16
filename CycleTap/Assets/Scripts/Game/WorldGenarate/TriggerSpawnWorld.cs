using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawnWorld : MonoBehaviour
{
    public GameObject This;

    
    private void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("triggered");
            FindObjectOfType<WorldGenarate>().SpawnTerrain();
            GameObject.Destroy(This);
        }

       


    }
}


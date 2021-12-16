using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenarate : MonoBehaviour
{
    public GameObject[] terrains;
    public Transform Worlds;
    public int TerrainLenght;
    public int _terrainlenght;


    private void Start()
    {
        SpawnTerrain1();
        
       
    }

  
    public GameObject SpawnTerrain1()
    {
      GameObject CurrentTerrain = GetRandomTerrain();
        if (!CurrentTerrain)
        {
            return null;
        }

         GameObject _new = Instantiate(CurrentTerrain);
       // _new.transform.parent = Worlds;
        float _z = 0;
        _new.transform.position = Vector3.forward * _z;
        return _new;
    }


    public GameObject SpawnTerrain()
    {
       GameObject CurrentTerrain = GetRandomTerrain();

        if (!CurrentTerrain)
        {
            return null;
        }

        GameObject _new = Instantiate(CurrentTerrain);
       _new.transform.parent = Worlds;

        float _z = _terrainlenght;
        _new.transform.position = Vector3.forward * _z;
        _terrainlenght = _terrainlenght + TerrainLenght;    
        return _new;
    }
   

    private GameObject GetRandomTerrain()
    {



        if (terrains.Length == 0)
        {
            Debug.LogWarning("Trying to get a random terrain, but no terrain were found pp ");
            return null;
        }
        int _random = Random.Range(0, terrains.Length);
        return terrains[_random];

    }
}

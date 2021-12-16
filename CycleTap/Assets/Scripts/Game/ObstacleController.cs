
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public Transform gameMap; // parent for obsticles
    public Transform gameMap2;// parent for pickups
    [Space]
    public GameObject[] obstacles01, obstacles02, obstacles03, obstacles04, obstacles05;
    [Space]
    [Space]
    public GameObject[] pickups01, pickups02, pickups03, pickups04, pickups05;
   // public float intervalMin = 6.0f, intervalMax = 10.0f;
     [Space]
    public float interval;
    public float Interval;
    [Space]
    public float intervalPickup;
    public float IntervalPickup;
    [Space]
    public float intervalCoin;
    public float IntervalCoin;
    [Space]
    public int MaxObjectSpawn = 4;
    public int MaxPickupSpawn = 4;
    [Space]
    public GameController gmc; //Game controler script
    [Space]
    public int Lvl01, Lvl02, Lvl03, Lvl04;


    private bool DropPickup;
    private List<GameObject> m_Obstacles;
    private List<GameObject> m_Pickups;

    public int ObstacklespawnAtaTime = 10;
    #region Unity Functions
    private void Awake()
    {
        m_Obstacles = new List<GameObject>();
        m_Pickups = new List<GameObject>();
      

    }
    private void Update() 
    {
      
    }

    #endregion
    int i;
    #region Public Functions
    public void AddObstacle()
    {
      //  Debug.Log("Addobs running");

        while (i < MaxObjectSpawn)
        {
            i++;
            GameObject _prefab = GetRandomObstacle();
            if (!_prefab)
            {
                return;
            }

            GameObject _new = Instantiate(_prefab);

            _new.transform.parent = gameMap;
            float _z = interval;

            _new.transform.position = Vector3.forward * _z;
            interval = interval + Interval;
            m_Obstacles.Insert(0,_new);
           
            return;

        }

    }
    public void Reseti()
    {

        i = MaxObjectSpawn - 1;

    }
    public void ResetI()
    {

        I = MaxPickupSpawn - 1;

    }

    public void Reset()
    {
        for (int i = m_Obstacles.Count - 1; i >= 0; i--)
        {
            Destroy(m_Obstacles[i]);
            m_Obstacles.RemoveAt(i);
        }
        for (int i = m_Pickups.Count - 1; i >= 0; i--)
        {
            if (m_Pickups[i] != null)
            {
                Destroy(m_Pickups[i]);
            }
           
            m_Pickups.RemoveAt(i);
        }
    }

    
    int I;
    public void AddPickup()
    {


        while (I < MaxPickupSpawn)
        {
            I++;
            GameObject _prefab = GetRandomPickup();
            if (!_prefab)
            {
                return;
            }

            GameObject _new = Instantiate(_prefab);
            _new.transform.parent = gameMap2;
            float _z = intervalCoin;
           
            _new.transform.position = Vector3.forward * _z;
            intervalCoin = intervalCoin + IntervalCoin;
            m_Pickups.Insert(0, _new);
        }
    }


    #endregion

    #region Private Functions
    private GameObject GetRandomObstacle()
    {

        if (gmc.PlayerScore() >= 0 && gmc.PlayerScore() <= Lvl01)
        {
            if (obstacles01.Length == 0)
            {
                Debug.LogWarning("Trying to get a random obstacles01, but no obstacles were found");
                return null;
            }
            int _random = Random.Range(0, obstacles01.Length);
            return obstacles01[_random];
        }
        else if (gmc.PlayerScore() > Lvl01 && gmc.PlayerScore() <= Lvl02)
        {
            if (obstacles02.Length == 0)
            {
                Debug.LogWarning("Trying to get a random obstacles02, but no obstacles were found");
                return null;
            }
            int _random = Random.Range(0, obstacles02.Length);
            return obstacles02[_random];
        }
        else if (gmc.PlayerScore() > Lvl02 && gmc.PlayerScore() <= Lvl03)
        {
            if (obstacles03.Length == 0)
            {
                Debug.LogWarning("Trying to get a random obstacles03, but no obstacles were found");
                return null;
            }
            int _random = Random.Range(0, obstacles03.Length);
            return obstacles03[_random];
        }
        else if (gmc.PlayerScore() > Lvl03 && gmc.PlayerScore() <= Lvl04)
        {
            if (obstacles04.Length == 0)
            {
                Debug.LogWarning("Trying to get a random obstacles04, but no obstacles were found");
                return null;
            }
            int _random = Random.Range(0, obstacles04.Length);
            return obstacles04[_random];

        }
        else if (gmc.PlayerScore() >= Lvl04)
        {
            if (obstacles05.Length == 0)
            {
                Debug.LogWarning("Trying to get a random obstacles05, but no obstacles were found");
                return null;
            }
            int _random = Random.Range(0, obstacles05.Length);
            return obstacles05[_random];

        }
        else
        {
            Debug.LogWarning("Trying to get a random obstacles, but no obstacles were found 022");
            return null;
            
        }


    }






    private GameObject GetRandomPickup()
    {
          
            if (intervalCoin >= intervalPickup)//gmc.PlayerScore() >= Lvl04)
            {  
            

               
                intervalPickup += IntervalPickup;
                if (pickups05.Length == 0)
                {
                    Debug.LogWarning("Trying to get a random obstacles05, but no obstacles were found pp");
                    return null;
                }
                int _random = Random.Range(0, pickups05.Length);

                return pickups05[_random];
            
           
            }
           
        
        else if (gmc.PlayerScore() >= 0 && gmc.PlayerScore() <= Lvl01)
        {
            if (pickups01.Length == 0)
            {
                Debug.LogWarning("Trying to get a random obstacles01, but no obstacles were found pp ");
                return null;
            }
            int _random = Random.Range(0, pickups01.Length);
            return pickups01[_random];
        }
        else if (gmc.PlayerScore() > Lvl01 && gmc.PlayerScore() <= Lvl02)
        {
            if (pickups02.Length == 0)
            {
                Debug.LogWarning("Trying to get a random obstacles02, but no obstacles were found pp");
                return null;
            }
            int _random = Random.Range(0, pickups02.Length);
            return pickups02[_random];
        }
        else if (gmc.PlayerScore() > Lvl02 && gmc.PlayerScore() <= Lvl03)
        {
            if (pickups03.Length == 0)
            {
                Debug.LogWarning("Trying to get a random obstacles03, but no obstacles were found pp");
                return null;
            }
            int _random = Random.Range(0, pickups03.Length);
            return pickups03[_random];
        }
        else if (gmc.PlayerScore() > Lvl03)
        {
            if (pickups04.Length == 0)
            {
                Debug.LogWarning("Trying to get a random obstacles04, but no obstacles were found pp");
                return null;
            }
            int _random = Random.Range(0, pickups04.Length);
            return pickups04[_random];

        }
        
        else
        {
            Debug.LogWarning("Trying to get a random obstacles, but no obstacles were found 022");
            return null;

        }


    }
    #endregion
}

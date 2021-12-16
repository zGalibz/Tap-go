
using UnityEngine;

public class SpawnTrees : MonoBehaviour
{
     public GameObject[] SpawnPoints;
    public GameObject[] Trees;
    [Space]
    public Transform ParentForTree;
    public Transform ParentForGrass;
    public Transform ParentForStone;
    [Space]
    public int MaxTree;
    [Space]
    public bool Tree;
    public bool Grass;
    public bool Stone;
    public bool Fixedposition;
      
    void Update()
    {
        DedicatedSpawnPoints();
    }
       int i = 1;
private void DedicatedSpawnPoints()
    { //Spawning and chosing spawnpoint and trees at same time

        while (MaxTree >= i)
        {
            i++;
            GameObject _Spawnpoint = ChooseRandomSpwanpoint();
            GameObject _ChoosedTree = ChooseRandomTree();

           
            if (!_Spawnpoint || !_ChoosedTree)
            {
                return;
            }
           System.Collections.Generic.List<GameObject> list = new System.Collections.Generic.List<GameObject>(SpawnPoints);//crates list
            list.Remove(_Spawnpoint);
            SpawnPoints = list.ToArray();
            GameObject Tree = Instantiate(_ChoosedTree);
            SetParent(Tree);
            Tree.transform.position = new Vector3(_Spawnpoint.transform.position.x,_Spawnpoint.transform.position.y /*Tree.transform.position.y-1.6f*/,_Spawnpoint.transform.position.z);
            Debug.Log(i);
            
        }
    }
    
       private GameObject ChooseRandomSpwanpoint()
    {
        if (SpawnPoints.Length == 0)
        {
            Debug.Log("Trying to get a random spwnpoint but no spawn point found");
            return null;
        }
        int _random = Random.Range(0, SpawnPoints.Length);
        return SpawnPoints[_random];

    }
     private void SetParent(GameObject _new)
    {
        if (Tree && Grass || Tree && Stone || Grass && Stone || Tree && Stone && Grass )
        {
            Debug.LogError("Multiple objects are selected for parent of RandomTree,Grass,Stone Genarator");
          
        }
        if (Tree)
        {
            _new.transform.parent = ParentForTree;
        }
       if (Grass)
        {
            _new.transform.parent = ParentForGrass;
        }
        if (Stone)
        {
            _new.transform.parent = ParentForStone;
        }

    }
    private GameObject ChooseRandomTree()
    {
        if (Trees.Length == 0)
        {
            Debug.Log("Trying to get a random Tree but no tree point found");
            return null;
        }
        int _random = Random.Range(0, Trees.Length);
        return Trees[_random];

    }
}

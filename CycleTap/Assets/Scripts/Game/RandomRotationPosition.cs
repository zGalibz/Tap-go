using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotationPosition : MonoBehaviour
{

  

    void Awake()
    {
       transform.Rotate(new Vector3(0,Random.Range(0,360),0),Space.Self);
    }
}

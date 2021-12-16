using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDeleteWorld : MonoBehaviour
{
    public GameObject world;
    public GameObject This;
    public string Tag;
    public bool ResetiObsticle = false;
    public bool ResetIPickup = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(Tag))
        {
           
            GameObject.Destroy(world);
            GameObject. Destroy(This);

            if (ResetiObsticle == true)
            {
                FindObjectOfType<ObstacleController>().Reseti();
            }
            if (ResetIPickup == true)
            {
                FindObjectOfType<ObstacleController>().ResetI();
            }


        }
    }
}

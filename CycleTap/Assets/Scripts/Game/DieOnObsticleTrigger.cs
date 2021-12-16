
using UnityEngine;

public class DieOnObsticleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameController.instance.Die();
        }
    }
}

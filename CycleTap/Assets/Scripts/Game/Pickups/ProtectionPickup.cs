
using UnityEngine;

public class ProtectionPickup : Pickup
{
    [SerializeField] ParticleSystem ps = null;
      
    public float duration;
   
    #region Override Function
    protected override void OnPlayerCollect()
    {
        base.OnPlayerCollect();
        Collect();
        game.HandleProtectionPickup(duration);
       
      

    }
    private void Update() {
       
    }
    public void Collect()
    {
        ps.Play();
    }

    #endregion

}

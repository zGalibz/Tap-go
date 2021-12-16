
using UnityEngine;

public class CoinMultiplier_Pickup : Pickup
{
    public int Multiplier;
    public float duration;
    #region Override Function
    protected override void OnPlayerCollect()
    {
        base.OnPlayerCollect();
        game.HandleCoinMultiplierPickUp(Multiplier,duration);

    }
    #endregion

}

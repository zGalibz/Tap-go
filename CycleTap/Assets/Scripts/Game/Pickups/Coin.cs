using UnityEngine;

public class Coin : Pickup
{
    public int CoinValue;
    [SerializeField] ParticleSystem ps = null;
    #region Override Function


    protected override void OnPlayerCollect()
    {
        base.OnPlayerCollect();
        game.HandleCoin(CoinValue);
        Collect();
        game.TotalCoins = game.TotalCoins + CoinValue;
        game.TextTotalcoin.text = game.TotalCoins.ToString();

    }
    public void Collect()
    {
        ps.Play();
    }

    #endregion

}
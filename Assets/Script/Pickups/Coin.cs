using UnityEngine;

public class Coin : Pickups
{

    CoinManager CoinM;
    [SerializeField] int CoinAmount = 1;


    public void Init(CoinManager CoinM)
    {
        this.CoinM = CoinM;
    }
    protected override void DoPickups()
    {
        Debug.Log("Add " + CoinAmount + " coins");
        CoinM.AddCoins(CoinAmount);
    }
}

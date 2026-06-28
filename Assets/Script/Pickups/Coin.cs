using UnityEngine;

public class Coin : Pickups
{

    CoinManager CoinM;
    [SerializeField] int CoinAmount = 1;

    private void Start()
    {
        CoinM = FindFirstObjectByType<CoinManager>();
    }
    protected override void DoPickups()
    {
        Debug.Log("Add " + CoinAmount + " coins");
        CoinM.AddCoins(CoinAmount);
    }
}

using UnityEngine;

public class Coin : Pickups
{
    protected override void DoPickups()
    {
        Debug.Log("Add 100 coins");
    }
}

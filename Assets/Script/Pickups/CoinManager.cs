using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    
 int coinCount = 0;
[SerializeField] TMP_Text CoinText;

[SerializeField] GameManagers gameManagers;

    public void AddCoins(int CoinAmount)
    {
        if (gameManagers.GameOver) return;
        coinCount+= CoinAmount;
        CoinText.text = coinCount.ToString();
    }
}

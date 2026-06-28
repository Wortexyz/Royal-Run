using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    
 int coinCount = 0;
[SerializeField] TMP_Text CoinText;

    public void AddCoins(int CoinAmount)
    {
        coinCount+= CoinAmount;
        CoinText.text = coinCount.ToString();
    }
}

using TMPro;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
   
   [SerializeField] float startingTime= 5f;
   [SerializeField] TMP_Text timerText ;
   [SerializeField] GameObject gameoverText;
   [SerializeField] PlayerMovemnt playerMovemnt;
   float timeRemaining;
   bool gameIsOver = false;


   public bool GameOver
    {
        get { return gameIsOver;    }
        set { gameIsOver = value; }
    }
    void Start()
    {
        timeRemaining = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsOver == true) return;
        timeRemaining -= Time.deltaTime;
        timerText.text = timeRemaining.ToString("f1");
        if (timeRemaining <= 0)
        {
            ReduceTime();
        }

      
    }

    public void IncreaseTime(float timeToAdd)
    {
        timeRemaining += timeToAdd;
    }

    void ReduceTime()
    {
        playerMovemnt.enabled = false;  
        gameoverText.SetActive(true);
        Time.timeScale = .1f;
        gameIsOver = true;
    }
}

using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameManagers gameManagers;
    [SerializeField] float timeToAdd = 5f;
    void Start()
    {
        gameManagers = FindFirstObjectByType<GameManagers>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManagers.IncreaseTime(timeToAdd);
            
        }
    } 
}

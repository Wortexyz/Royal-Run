using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
     GameManagers gameManagers;
     ObstacleSpawner obstacleSpawner;
    [SerializeField] float timeToAdd = 5f , decreasingTime = 0.2f;
    void Start()
    {
        gameManagers = FindFirstObjectByType<GameManagers>();
        obstacleSpawner = FindFirstObjectByType<ObstacleSpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManagers.IncreaseTime(timeToAdd);
            obstacleSpawner.DecreasingSpawnTime(decreasingTime);
        }
    } 
}

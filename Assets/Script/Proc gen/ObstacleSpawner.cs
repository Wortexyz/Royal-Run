using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> obstacleList = new List<GameObject>();   
    [SerializeField] Transform ObstacleParent;
    [SerializeField] float SpawnTime=3f , SpawnXPos =3f;
 

    private void Start()
    {
        StartCoroutine(SpawnObstacle());   
        
    }

    IEnumerator SpawnObstacle()
    {

        while(true)
        {
            GameObject Obstacle = obstacleList[Random.Range(0,obstacleList.Count)];
            Vector3 SpawningPos = new Vector3(  Random.Range(-SpawnXPos,SpawnXPos),transform.position.y,transform.position.z);
            yield return new WaitForSeconds(SpawnTime);
            Instantiate(Obstacle , SpawningPos , Random.rotation , ObstacleParent);
           
            
        }
       
    }
}

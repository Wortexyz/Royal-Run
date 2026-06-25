using System.Collections.Generic;
using UnityEngine;

public class Fences : MonoBehaviour
{
    [SerializeField] GameObject FencePrefab;
    [SerializeField] GameObject ApplePrefab;
    [SerializeField] GameObject CoinPrefab;
    [SerializeField] float AppleChanceToSpawn = .3f;
    [SerializeField] float coinChanceToSpawn = .5f;
    [SerializeField] float coinSeperationLength = 1.5f;

    [SerializeField] float[] Lanes = { -2.5f, 0f, 2.5f };
    List<int> availableLanes = new List<int>() { 0,1,2};

    private void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoin();
    }

    void SpawnFence()
    {
        int FenceToSpawn = Random.Range(0, Lanes.Length);

        for (int i = 0; i < FenceToSpawn; i++)
        {

            if (availableLanes.Count <= 0) break;

            int selectedLine = SelectLine();
            Vector3 SpawnPos = new Vector3(Lanes[selectedLine], transform.position.y, transform.position.z);

            Instantiate(FencePrefab, SpawnPos, Quaternion.identity, this.transform);
        }
    }

     int SelectLine()
    {
        int RandomLineIndex = Random.Range(0, availableLanes.Count);
        int selectedLine = availableLanes[RandomLineIndex];
        availableLanes.RemoveAt(RandomLineIndex);
        return selectedLine;
    }

    void SpawnApple()
    {
        if (availableLanes.Count <= 0 || Random.value > AppleChanceToSpawn) return;
        int selectedLine = SelectLine();
        Vector3 SpawnPos = new Vector3(Lanes[selectedLine], transform.position.y, transform.position.z);

        Instantiate(ApplePrefab, SpawnPos, Quaternion.identity, this.transform);
    }

    void SpawnCoin()
    {
        if (availableLanes.Count <= 0 || Random.value > coinChanceToSpawn) return;
        
        int selectedLine = SelectLine();

        int coinToSpawnNumber = Random.Range(1, 6);
        float coinStartpos = transform.position.z + (2 * coinSeperationLength);
        for (int i = 0; i < coinToSpawnNumber; i++)
        {
            float SpawncoinZ = coinStartpos - (i * coinSeperationLength);   
        Vector3 SpawnPos = new Vector3(Lanes[selectedLine], transform.position.y, SpawncoinZ);

        Instantiate(CoinPrefab, SpawnPos, Quaternion.identity, this.transform);
            
            
        }
        
    }
}

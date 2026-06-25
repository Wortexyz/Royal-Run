using System.Collections.Generic;
using UnityEngine;

public class Fences : MonoBehaviour
{
    [SerializeField] GameObject FencePrefab;
    [SerializeField] float[] Lanes = { -2.5f, 0f, 2.5f };
    List<int> availableLanes = new List<int>() { 0,1,2};

    private void Start()
    {
        SpawnFence();
    }

    void SpawnFence()
    {
        int FenceToSpawn = Random.Range(0, Lanes.Length);

        for (int i = 0; i < FenceToSpawn; i++)
        {


            int RandomLineIndex = Random.Range(0, availableLanes.Count);
            int selectedLine = availableLanes[RandomLineIndex];
            availableLanes.RemoveAt(RandomLineIndex);
            Vector3 SpawnPos = new Vector3(Lanes[selectedLine], transform.position.y, transform.position.z);

            Instantiate(FencePrefab, SpawnPos, Quaternion.identity, this.transform);
        }
    }
}

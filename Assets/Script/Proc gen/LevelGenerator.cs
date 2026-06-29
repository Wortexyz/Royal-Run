using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] GameObject CheckPointChunkPrefab;

    [SerializeField] Transform chunkParent;
    [SerializeField] CoinManager coinManager;

    [Header("Level Settings")]
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f, minMoveSpeed = 2f ,maxMoveSpeed=20f, MinimumGravity = -9.8f, MaximumGravity = -30f  , CheckpointSpawningintervel =8f;

    List<GameObject> chunks = new List<GameObject>();

    float chunkNumber = 0f;

    void Start()
    {
        SpawnStartingChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    public void changingMoveSpeed( float movespeedArg)
    {
        moveSpeed += movespeedArg;
        if (moveSpeed < minMoveSpeed)
        { 
            moveSpeed = minMoveSpeed;
        }
        else if (moveSpeed > maxMoveSpeed)
        {
            moveSpeed = maxMoveSpeed;
        }

        float LeastGravity = Mathf.Clamp(Physics.gravity.z - movespeedArg, MaximumGravity, MinimumGravity);

        Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, LeastGravity);

        cameraController.ChangeCameraFOV(movespeedArg);
        
    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

        GameObject NewChunkToSpawn = FindChunkToSpawn();

        GameObject newChunkGO = Instantiate(NewChunkToSpawn, chunkSpawnPos, Quaternion.identity, chunkParent);

        chunks.Add(newChunkGO);
        Fences newChunk = newChunkGO.GetComponentInChildren<Fences>();
        newChunk.Init(this, coinManager);
        chunkNumber++;
    }

     GameObject FindChunkToSpawn()
    {
        GameObject NewChunkToSpawn;
        if (chunkNumber % CheckpointSpawningintervel == 0 && chunkNumber != 0)
        {
            NewChunkToSpawn = CheckPointChunkPrefab;
        }
        else
        {

            NewChunkToSpawn = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];

        }

        return NewChunkToSpawn;
    }

    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;

        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength;
        }

        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}
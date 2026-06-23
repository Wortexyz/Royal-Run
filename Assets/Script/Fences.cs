using UnityEngine;

public class Fences : MonoBehaviour
{



    [SerializeField] GameObject FencePrefab;
    [SerializeField] float[] SpawnXPos = { -2.5f, 0f, 2.5f };

    private void Start()
    {
        SpawnFence();
    }







    void SpawnFence()
    {
        int x = Random.Range(0, SpawnXPos.Length);
        Vector3 SpawnPos = new Vector3(SpawnXPos[x],transform.position.y, transform.position.z);

        Instantiate(FencePrefab , SpawnPos , Quaternion.identity ,this.transform);
    }
}

using UnityEngine;

public class Pickups : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);

        }
    }
}

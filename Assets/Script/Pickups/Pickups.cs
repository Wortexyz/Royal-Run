using UnityEngine;

public abstract class Pickups : MonoBehaviour
{
    [SerializeField] float RotateSpeed = 100f;
    private void Update()
    {
        transform.Rotate(0, RotateSpeed * Time.deltaTime,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DoPickups();
            Destroy(gameObject);

        }
    }



    protected abstract void DoPickups();
}

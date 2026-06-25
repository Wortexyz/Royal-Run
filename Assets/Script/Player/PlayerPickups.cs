using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
       
        Debug.Log(collision.gameObject.name);
            
        
    }
}

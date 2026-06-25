using UnityEngine;

public class PlayerPickups : MonoBehaviour
{
    [SerializeField] Animator animator;
     float cooldownTimer;
    [SerializeField] float changingSpeed = -2f;

    LevelGenerator levelGenerator;
    private void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    private void Update()
    {
        cooldownTimer += Time.time;
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        Debug.Log(collision.gameObject.name);

        if ( cooldownTimer <2f ) return;
        animator.SetTrigger("Hit");
        levelGenerator.changingMoveSpeed(changingSpeed) ; 
        cooldownTimer = 0f;
            
        
    }
}

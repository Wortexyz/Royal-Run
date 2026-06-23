using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovemnt : MonoBehaviour
{
    float xPos, yPos;
    [SerializeField] float movespead=10f;
    Rigidbody rb;
 InputAction Player ;
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

   void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 currentPos = rb.position;
        Vector3 Movedirection = new Vector3(xPos, 0, yPos);
        Vector3 NewPosition = currentPos + Movedirection * (movespead * Time.deltaTime);
        rb.MovePosition(new Vector3 ( Mathf.Clamp(NewPosition.x,-3,3),NewPosition.y,Mathf.Clamp(NewPosition.z,-1,3)));
    }




    public void OnMove(InputValue value)
    {
        Vector2 Pos = value.Get<Vector2>();
         xPos = Pos.x;
         yPos = Pos.y;
       
        
        
    }

    
}

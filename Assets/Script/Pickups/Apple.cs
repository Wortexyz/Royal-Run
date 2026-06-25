using UnityEngine;

public class Apple : Pickups
{
    LevelGenerator LevelGenerator;
    [SerializeField] float AddingSpeed = 3f;
    
    private void Start()
    {
        LevelGenerator = FindFirstObjectByType<LevelGenerator>();
    }
    protected override void DoPickups()
    {
        Debug.Log("PowerUps here");
        
        
        LevelGenerator.changingMoveSpeed(AddingSpeed);
            
        
    }
}

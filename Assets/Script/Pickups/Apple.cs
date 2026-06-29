using UnityEngine;

public class Apple : Pickups
{
    LevelGenerator levelGenerator;
    [SerializeField] float AddingSpeed = 3f;
    
    public void Init( LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }
    protected override void DoPickups()
    {
        Debug.Log("PowerUps here");
        
        
        levelGenerator.changingMoveSpeed(AddingSpeed);
            
        
    }
}

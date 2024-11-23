using UnityEngine;

public class MoveComponent : AbilityComponent
{
    public enum Direction
    {
        Forward,
        Backward,
        Left,
        Right
    }
    
    private float _speed;
    private Direction _direction;
    
    public MoveComponent(float speed, Direction direction)
    {
        _speed = speed;
        _direction = direction;
    }

    public override void StartExecute(CharacterComponentsContainer container)
    {
       
    }

    public override void FinishExecute(CharacterComponentsContainer container)
    {
        
    }
}

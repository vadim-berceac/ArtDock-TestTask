using DG.Tweening;
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
    
    private readonly float _speed;
    private readonly Direction _direction;
    private Tween _moveTween;
    
    public MoveComponent(float speed, Direction direction)
    {
        _speed = speed;
        _direction = direction;
    }

    public override void StartExecute(CharacterComponentsContainer container)
    {
        var directionVector = Vector3.zero;

        switch (_direction)
        {
            case Direction.Forward:
                directionVector = container.transform.forward;
                break;
            case Direction.Backward:
                directionVector = -container.transform.forward;
                break; 
            case Direction.Left: 
                directionVector = -container.transform.right;
                break;
            case Direction.Right: 
                directionVector = container.transform.right; 
                break;
        } 
        
        _moveTween = container.transform.DOMove(container.transform.position + directionVector * _speed, 1f)
            .SetLoops(-1, LoopType.Incremental) .SetEase(Ease.Linear);
    }

    public override void FinishExecute(CharacterComponentsContainer container)
    {
        if (_moveTween != null && _moveTween.IsActive())
        {
            _moveTween.Kill();
        }
    }
}

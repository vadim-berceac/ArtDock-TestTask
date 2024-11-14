[System.Serializable]
public class PlayAnimationComponent : AbilityComponent
{
    private string _animationName;

    public PlayAnimationComponent(string animationName)
    {
        _animationName = animationName;
    }

    public override void Execute(CharacterComponentsContainer container)
    {
        if (container.Animator == null)
        {
            return;
        }
        container.Animator.Play(_animationName);
    }
}
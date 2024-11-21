using UnityEngine;

[System.Serializable]
public class AbilityComponentConfig
{
    public enum ComponentType
    {
        PlayAnimation, PlaySound, AreaDamage
    } 
    public ComponentType componentType;
    
    //animation component
    [SerializeField] private string animationName;
    [SerializeField] private float animationDuration;
    
    //sound component
    [SerializeField] private AudioClip soundClip; 
    
    //area damage component
    [SerializeField] private float radius; 
    [SerializeField] private int damage;
    [SerializeField] private int colliderCount;

    public AbilityComponent CreateComponent()
    {
        switch (componentType)
        {
            case ComponentType.PlayAnimation:
                return new PlayAnimationComponent(animationName);
            
            case ComponentType.PlaySound: 
                return new PlaySoundComponent(soundClip);
            
            case ComponentType.AreaDamage:
                return new AreaDamageComponent(radius, damage, colliderCount);
            
            default:
                return null;
        }
    }
}

using UnityEngine;

[System.Serializable]
public class AbilityComponentConfig
{
    public enum ComponentType
    {
        PlayAnimation, PlaySound, AreaDamage
    } 
    public ComponentType componentType;
    public string animationName; 
    public AudioClip soundClip;
    public float radius;
    public int damage;

    public AbilityComponent CreateComponent()
    {
        switch (componentType)
        {
            case ComponentType.PlayAnimation:
                return new PlayAnimationComponent(animationName);
            
            case ComponentType.PlaySound: 
                return new PlaySoundComponent(soundClip);
            
            case ComponentType.AreaDamage:
                return new AreaDamageComponent(radius, damage, 16);
            
            default: return null;
        }
    }
}

using UnityEngine;

[System.Serializable]
public class AbilityComponentConfig
{
    public enum ComponentType
    {
        PlayAnimation, PlaySound, AreaDamage,
        PlayParticle, Move, Buff
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
    [SerializeField] private bool rotateToFirstTarget;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Ability responseAbility;
    
    //particle component
    [SerializeField] private GameObject effectPrefab;
    
    //move component
    [SerializeField] private float speed;
    [SerializeField] private MoveComponent.Direction moveDirection;
    
    //buff component
    [SerializeField] private int increaseStrength;
    [SerializeField] private int increaseAgility;
    [SerializeField] private int increaseDefence;

    public AbilityComponent CreateComponent()
    {
        switch (componentType)
        {
            case ComponentType.PlayAnimation:
                return new PlayAnimationComponent(animationName);
            
            case ComponentType.PlaySound: 
                return new PlaySoundComponent(soundClip);
            
            case ComponentType.AreaDamage:
                return new AreaDamageComponent(radius, damage, colliderCount, layerMask, rotateToFirstTarget,
                    responseAbility);
            
            case ComponentType.PlayParticle:
                return new PlayParticlesComponent(effectPrefab);
            
            case ComponentType.Move:
                return new MoveComponent(speed, moveDirection);
             
            case ComponentType.Buff:
                return new BuffComponent(increaseStrength, increaseAgility, increaseDefence);
            
            default:
                return null;
        }
    }
}

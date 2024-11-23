using UnityEngine;

[System.Serializable] 
public class AreaDamageComponent : AbilityComponent 
{
    private float _radius; 
    private int _damage;
    private int _colliderCount;
    private bool _rotateToFirstTarget;
    private LayerMask _layer;
    private Ability _responseAbility;

    public AreaDamageComponent(float radius, int damage, int colliderCount, LayerMask layer, bool rotateToFirstTarget,
        Ability ability = null)
    {
        _radius = radius; 
        _damage = damage;
        _colliderCount = colliderCount;
        _rotateToFirstTarget = rotateToFirstTarget;
        _layer = layer;
        _responseAbility = ability;
    } 
    
    public override void StartExecute(CharacterComponentsContainer container)
    {
        if (container.DamageMaker == null)
        {
            return;
        }
        
        container.DamageMaker.CauseDamage(container.CashedTransform, _radius, _damage, _colliderCount,
            _layer, _responseAbility, _rotateToFirstTarget);
    }

    public override void FinishExecute(CharacterComponentsContainer container)
    {
        
    }
}

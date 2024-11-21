using UnityEngine;

[System.Serializable] 
public class AreaDamageComponent : AbilityComponent 
{
    private float _radius; 
    private int _damage;
    private int _colliderCount;
    private LayerMask _layer;
    private Ability _responseAbility;

    public AreaDamageComponent(float radius, int damage, int colliderCount, LayerMask layer, Ability ability = null)
    {
        _radius = radius; 
        _damage = damage;
        _colliderCount = colliderCount;
        _layer = layer;
        _responseAbility = ability;
    } 
    
    public override void StartExecute(CharacterComponentsContainer container)
    {
        if (container.AreaDamage == null)
        {
            return;
        }
        
        container.AreaDamage.Damage(container.CashedTransform, _radius, _damage, _colliderCount,
            _layer, _responseAbility);
    }

    public override void FinishExecute(CharacterComponentsContainer container)
    {
        
    }
}

using UnityEngine;

[System.Serializable] 
public class AreaDamageComponent : AbilityComponent 
{
    private float _radius; 
    private int _damage;
    private int _colliderCount;

    public AreaDamageComponent(float radius, int damage, int colliderCount)
    {
        _radius = radius; 
        _damage = damage;
        _colliderCount = colliderCount;
    } 
    
    public override void Execute(CharacterComponentsContainer container)
    {
        var hitColliders = new Collider[_colliderCount];
        
        Physics.OverlapSphereNonAlloc(container.CashedTransform.position, _radius, hitColliders);

        foreach (var hitCollider in hitColliders)
        {
            Debug.Log($"Damaged {hitCollider.name} for {_damage} damage.");
        } 
    }
}

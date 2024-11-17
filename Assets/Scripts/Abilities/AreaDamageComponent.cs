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
        if (container.AreaDamage == null)
        {
            return;
        }
        
        container.AreaDamage.Damage(container.CashedTransform, _radius, _damage, _colliderCount);
    }
}

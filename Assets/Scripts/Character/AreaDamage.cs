using UnityEngine;

public class AreaDamage : MonoBehaviour
{
    // test component without logic
    public void Damage(Transform character, float radius, float damage, int colliderCount, LayerMask layerMask)
    {
        var hitColliders = new Collider[colliderCount];
        
        Physics.OverlapSphereNonAlloc(character.position, radius, hitColliders);

        if (hitColliders.Length == 0)
        {
            return;
        }
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider != null && !hitCollider.transform.IsChildOf(character) 
                                    && (layerMask.value & (1 << hitCollider.gameObject.layer)) != 0)
            {
                var c = hitCollider.GetComponentInParent<CharacterComponentsContainer>();
                if (c == null || c.Animator == null)
                {
                    return;
                }
                c.Animator.Play("GetHit");
                Debug.Log($"Damaged {hitCollider.name} for {damage} damage.");
            }
        } 
    }
}

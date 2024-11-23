using DG.Tweening;
using UnityEngine;

public class DamageMaker : MonoBehaviour
{
    // test component without logic
    public void CauseDamage(Transform character, float radius, float damage, int colliderCount, LayerMask layerMask,
        Ability responseAbility = null, bool rotateToFirst = false)
    {
        var hitColliders = new Collider[colliderCount];
        
        Physics.OverlapSphereNonAlloc(character.position, radius, hitColliders);

        if (hitColliders.Length == 0)
        {
            return;
        }
        Collider firstValidCollider = null;
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider != null && !hitCollider.transform.IsChildOf(character) 
                                    && (layerMask.value & (1 << hitCollider.gameObject.layer)) != 0) 
            { 
                var c = hitCollider.GetComponentInParent<CharacterComponentsContainer>();

                if (c == null || c.Animator == null)
                {
                    continue;
                }

                if (firstValidCollider == null)
                {
                    firstValidCollider = hitCollider;
                }

                if (responseAbility != null)
                {
                    c.AbilityPlayer.SetAndStartAbility(responseAbility);
                }
                
                Debug.Log($"Damaged {hitCollider.name} for {damage} damage.");
            }
        } 
        
        if (!rotateToFirst || firstValidCollider == null)
        { 
            return;
        }
        
        var directionToTarget = (firstValidCollider.transform.position - character.position).normalized;
        var targetRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x,
            0, directionToTarget.z), Vector3.up);
        character.DORotateQuaternion(targetRotation, 0.5f);
    }
}

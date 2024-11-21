using UnityEngine;

[System.Serializable]
public class PlayParticlesComponent: AbilityComponent
{
    private GameObject _particlePrefab;
    
    private GameObject _particleParent;

    public PlayParticlesComponent(GameObject particlePrefab)
    {
        _particlePrefab = particlePrefab;
    }

    public override void StartExecute(CharacterComponentsContainer container)
    {
        if (_particlePrefab == null)
        {
            return;
        }
        _particleParent = GameObject.Instantiate(_particlePrefab, container.CashedTransform.position,
            container.CashedTransform.rotation, container.CashedTransform);
    }

    public override void FinishExecute(CharacterComponentsContainer container)
    {
        GameObject.Destroy(_particleParent);
        _particleParent = null;
    }
}

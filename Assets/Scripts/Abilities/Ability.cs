using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "New Ability")]
public class Ability : ScriptableObject
{
    [SerializeField] private string abilityName;
    [SerializeField] private float duration = 1f;
    [SerializeField] private AbilityComponentConfig[] componentConfigs;
    private AbilityComponent[] _components;
    
    public float Duration => duration;

    private void Initialize()
    {
        _components = new AbilityComponent[componentConfigs.Length];
        for (var i = 0; i < componentConfigs.Length; i++)
        {
            _components[i] = componentConfigs[i].CreateComponent();
        }
    }

    public void Activate(CharacterComponentsContainer container)
    {
        if (_components == null)
        {
            Initialize();
        }

        foreach (var component in _components)
        {
            component.StartExecute(container);
        }
    }

    public void Deactivate(CharacterComponentsContainer container)
    {
        if (_components == null)
        {
            return;
        }
        
        foreach (var component in _components)
        {
            component.FinishExecute(container);
        }
    }
}

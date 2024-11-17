using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Scriptable Objects/Ability")]
public class Ability : ScriptableObject
{
    [SerializeField] private string abilityName;
    [SerializeField] private AbilityComponentConfig[] componentConfigs;
    private AbilityComponent[] _components;

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
            component.Execute(container);
        }
    }
}

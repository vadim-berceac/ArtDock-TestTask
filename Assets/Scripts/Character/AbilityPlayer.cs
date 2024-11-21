using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(CharacterComponentsContainer))]
public class AbilityPlayer : MonoBehaviour
{
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private CharacterComponentsContainer container;
    
    [Header("Current attack ability")]
    [SerializeField] private Ability ability;
    
    private GameInput _gameInput;
    private float _currentPlayTime;
    private bool _isPlayed;

    [Inject]
    private void Construct(GameInput gameInput)
    {
        _gameInput = gameInput;
    }
    private void Awake()
    {
        if (!isPlayer)
        {
            return;
        }
        _gameInput.AttackAction.performed += ActionPerformed;
    }

    private void Update()
    {
        CheckAbilityPlayed();
    }
    
    private void OnDisable()
    {
        if (!isPlayer)
        {
            return;
        }
        _gameInput.AttackAction.performed -= ActionPerformed;
    }

    public void SetAndStartAbility(Ability ability)
    {
        this.ability = ability;
        ActionStart();
    }
    
    private void ActionPerformed(InputAction.CallbackContext obj)
    {
        ActionStart();
    }

    private void ActionStart()
    {
        if (ability == null || _isPlayed)
        {
            return;
        }
        
        _isPlayed = true;
        ability.Activate(container);
    }
    
    private void ActionEnd()
    {
        if (ability == null)
        {
            return;
        }
        
        _isPlayed = false;
        ability.Deactivate(container);
    }

    private void CheckAbilityPlayed()
    {
        if (!_isPlayed || ability == null)
        {
            _currentPlayTime = 0;
            return;
        }
        
        _currentPlayTime += Time.deltaTime;

        if (_currentPlayTime > ability.Duration)
        {
            ActionEnd();
        }
    }
}

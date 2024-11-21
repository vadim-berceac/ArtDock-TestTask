using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

[RequireComponent(typeof(CharacterComponentsContainer))]
public class AbilityPlayer : MonoBehaviour
{
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
        _gameInput.AttackAction.performed += AttackActionPerformed;
    }

    private void Update()
    {
        CheckAbilityPlayed();
    }
    
    private void OnDisable()
    {
        _gameInput.AttackAction.performed -= AttackActionPerformed;
    }
    
    private void AttackActionPerformed(InputAction.CallbackContext obj)
    {
        if (ability == null || _isPlayed)
        {
            return;
        }
        
        _isPlayed = true;
        ability.Activate(container);
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
            _isPlayed = false;
        }
    }
}

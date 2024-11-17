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
    private bool _isAnimationPlayed;

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
        CheckAnimationPlayed();
    }
    
    private void OnDisable()
    {
        _gameInput.AttackAction.performed -= AttackActionPerformed;
    }
    
    private void AttackActionPerformed(InputAction.CallbackContext obj)
    {
        if (ability == null)
        {
            return;
        }
        
        if (_isAnimationPlayed)
        {
           return;
        }
        
        _isAnimationPlayed = true;
        ability.Activate(container);
    }

    private void CheckAnimationPlayed()
    {
        if (!_isAnimationPlayed)
        {
            return;
        }
        if (container.Animator.GetCurrentAnimatorStateInfo (0).length 
            > container.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            _isAnimationPlayed = false;
        }
    }
}

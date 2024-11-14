using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputAsset;

    public InputAction MoveAction { get; private set; }
    public InputAction LookAction { get; private set; }
    public InputAction JumpAction { get; private set; }
    public InputAction AttackAction { get; private set; }

    private void Awake()
    {
        FindActions();
        EnableActions();
    }

    private void OnDisable()
    {
        DisableActions();
    }

    private void FindActions()
    {
        MoveAction = inputAsset.FindAction("Move");
        LookAction = inputAsset.FindAction("Look");
        JumpAction = inputAsset.FindAction("Jump");
        AttackAction = inputAsset.FindAction("Attack");
    }

    private void EnableActions()
    {
        MoveAction.Enable();
        LookAction.Enable();
        JumpAction.Enable();
        AttackAction.Enable();
    }

    private void DisableActions()
    {
        MoveAction.Disable();
        LookAction.Disable();
        JumpAction.Disable();
        AttackAction.Disable();
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSystem : MonoBehaviour, IAttack, IDamageable
{
    [SerializeField, Range(1, 100)] private int health = 50;
    [SerializeField] private InputActionReference attackAction;

    private AnimsPlayer _animsPlayer;
    private int _health;

    private bool _isAttacking = false;

    private void Awake()
    {
        _health = health;
        _animsPlayer = GetComponent<AnimsPlayer>();
        if (_animsPlayer == null) Debug.LogError("AttackSystem: AnimsPlayer not found.");
    }

    private void OnEnable()
    {
        attackAction.action.Enable();
        attackAction.action.performed += OnAttackPerformed;
        attackAction.action.canceled += OnAttackCanceled;
    }

    private void OnDisable()
    {
        attackAction.action.performed -= OnAttackPerformed;
        attackAction.action.canceled -= OnAttackCanceled;
        attackAction.action.Disable();
    }

    private void OnAttackPerformed(InputAction.CallbackContext ctx) => AttackDefault();
    private void OnAttackCanceled(InputAction.CallbackContext ctx)
    {
        _isAttacking = false;
        _animsPlayer.SetAttacking(false);
    }

    public void AttackDefault()
    {
        if (_isAttacking) return;
        _isAttacking = true;
        _animsPlayer.SetAttacking(true);
        Debug.Log("Attack performed");
    }

    public void Damage()
    {
        _health--;
        Debug.Log($"Damage received. HP: {_health}");

        if (_health <= 0)
        {
            _animsPlayer.SetDeath(true);
            Debug.Log("Player died.");
        }
    }
}
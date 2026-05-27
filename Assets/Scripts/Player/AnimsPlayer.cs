using UnityEngine;

public class AnimsPlayer : MonoBehaviour
{
    private Animator _animator;

    private const string IS_MOVING = "isMoving";
    private const string IS_ATTACKING = "isAttacking";
    private const string IS_TAKING_ITEM = "isTakingItem";
    private const string IS_DEATH = "isDeath";
    private const string IS_WIN = "isWin";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        if (_animator == null)
            Debug.LogError("AnimsPlayer: Animator not found.");
    }

    public void SetMoving(float speed) => _animator.SetFloat(IS_MOVING, speed);
    // 0 = Idle, 1 = Walk, 2 = Run

    public void SetAttacking(bool value) => _animator.SetBool(IS_ATTACKING, value);

    public void SetTakingItem(bool value) => _animator.SetBool(IS_TAKING_ITEM, value);

    public void SetDeath(bool value) => _animator.SetBool(IS_DEATH, value);

    public void SetWin(bool value) => _animator.SetBool(IS_WIN, value);
}
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;

    private AnimsPlayer _animsPlayer;
    private Rigidbody _rb;
    private Vector2 _moveInput;

    private const float WALK_SPEED = 3f;
    private const float ROTATION_SPEED = 120f; // grados/segundo

    private void Awake()
    {
        _animsPlayer = GetComponent<AnimsPlayer>();
        _rb = GetComponent<Rigidbody>();

        if (_animsPlayer == null) Debug.LogError("PlayerController: AnimsPlayer not found.");
        if (_rb == null) Debug.LogError("PlayerController: Rigidbody not found.");
    }

    private void OnEnable() => moveAction.action.Enable();
    private void OnDisable() => moveAction.action.Disable();

    private void Update()
    {
        _moveInput = moveAction.action.ReadValue<Vector2>();

        // A/D rotan el personaje (y por tanto la cámara también, ya que PT_MouseLook usa playerBody)
        if (_moveInput.x != 0)
            transform.Rotate(Vector3.up, _moveInput.x * ROTATION_SPEED * Time.deltaTime);

        // Animación
        _animsPlayer.SetMoving(_moveInput.y); // Walk forward
    }

    private void FixedUpdate()
    {
        // W/S mueven en el forward local del personaje
        Vector3 move = transform.forward * _moveInput.y * WALK_SPEED;
        _rb.linearVelocity = new Vector3(move.x, _rb.linearVelocity.y, move.z);
    }
}
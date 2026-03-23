using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int maxJumps = 2;

    [Header("Ground Detection")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;
    private int jumpsRemaining;
    private bool isGrounded;
    private InputAction jumpAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        jumpAction = new InputAction("Jump", InputActionType.Button);
        jumpAction.AddBinding("<Keyboard>/space");
        jumpAction.AddBinding("<Keyboard>/anyKey");
        jumpAction.AddBinding("<Gamepad>/buttonSouth");
        jumpAction.Enable();
    }

    private void Update()
    {
        CheckGrounded();

        if (jumpAction.WasPressedThisFrame())
            TryJump();

        if (transform.position.y < -10f)
            GameManager.Instance.GameOver();
    }


    private void OnDestroy()
    {
        jumpAction.Disable();
    }

    /// <summary>
    /// Tente de faire sauter le joueur si des sauts sont disponibles.
    /// </summary>
    private void TryJump()
    {
        if (jumpsRemaining <= 0) return;

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, 0f);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpsRemaining--;
    }

    private void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
            jumpsRemaining = maxJumps;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}

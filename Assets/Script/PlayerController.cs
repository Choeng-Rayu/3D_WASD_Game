using UnityEngine;

// Clean, simple Player movement for beginner assignment
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public CharacterController characterController;
    public float gravity = -9.81f;

    private Vector3 moveDirection;
    private Vector3 velocity = Vector3.zero;
    private bool isGrounded;

    void Start()
    {
        if (characterController == null)
            characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController == null)
            return;

        isGrounded = characterController.isGrounded;
        HandleInput();
        ApplyGravity();

        characterController.Move((moveDirection * moveSpeed + velocity) * Time.deltaTime);
    }

    void HandleInput()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDirection = transform.forward * v + transform.right * h;
        if (moveDirection.sqrMagnitude > 1f) moveDirection.Normalize();
    }

    void ApplyGravity()
    {
        if (isGrounded && velocity.y < 0f)
            velocity.y = -2f;
        else
            velocity.y += gravity * Time.deltaTime;
    }
}

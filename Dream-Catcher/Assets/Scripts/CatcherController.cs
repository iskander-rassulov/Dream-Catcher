using UnityEngine;

public class CatcherController : MonoBehaviour
{
    public float speed = 5.0f; // The movement speed of the player

    private Vector3 moveDirection = Vector3.zero; // The direction the player is moving in
    private Transform playerTransform;
    private Quaternion playerRotation;

    void Start()
    {
        playerTransform = transform;
        playerRotation = playerTransform.rotation;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Get the horizontal and vertical input axis (-1 for left/down, 1 for right/up)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Move the player based on the input
        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection = moveDirection.normalized * speed * Time.deltaTime;
        playerTransform.position += moveDirection;

        // Rotate the player to face the direction of the mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 lookDirection = hit.point - playerTransform.position;
            lookDirection.y = 0;
            playerRotation = Quaternion.LookRotation(lookDirection);
        }
        playerTransform.rotation = playerRotation;
    }
}




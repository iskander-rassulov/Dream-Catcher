using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // The movement speed of the player

    private Animator animator;
    private float moveDirection; // The direction the player is moving in

    void Update()
    {
        // Get the horizontal input axis (-1 for left, 1 for right)
        moveDirection = Input.GetAxisRaw("Horizontal");

        // Move the player left or right based on the input
        transform.position += new Vector3(moveDirection, 0, 0) * speed * Time.deltaTime;
    }
}
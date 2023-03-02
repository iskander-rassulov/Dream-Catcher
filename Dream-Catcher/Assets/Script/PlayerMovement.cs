using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // The movement speed of the player

    private Animator playerAnimator;
    private float moveDirection; // The direction the player is moving in
    private Transform playerTransform;
    void Start(){
        playerAnimator = GetComponent<Animator>();
        playerTransform = transform;
    }

    void LateUpdate()
    {
        // Get the horizontal input axis (-1 for left, 1 for right)
        moveDirection = Input.GetAxisRaw("Horizontal");

        // Move the player left or right based on the input
        transform.position += new Vector3(moveDirection, 0, 0) * speed * Time.deltaTime;

        //Animations
        if(playerAnimator != null){

            if (Mathf.Approximately(transform.rotation.eulerAngles.y, 0f))
            {return;}else transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("Right");

                playerAnimator.SetTrigger("Idle");

            if(Input.GetKey(KeyCode.A))
            {

            if (Mathf.Approximately(transform.rotation.eulerAngles.y, -90f))
            {return;}else transform.rotation = Quaternion.Euler(0f, -90f, 0f);

                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");

                playerAnimator.SetTrigger("Left");
            }

            if(Input.GetKey(KeyCode.D))
            {

            if (Mathf.Approximately(transform.rotation.eulerAngles.y, 90f))
            {return;}else transform.rotation = Quaternion.Euler(0f, 90.01f, 0f);

                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Left");

                playerAnimator.SetTrigger("Right");
            }
             
               
        }
    }
}
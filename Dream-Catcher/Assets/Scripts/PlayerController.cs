using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   
    private CharacterController characterController;
    public float mouseSensivity = 2f;
    private float characterRotationLeftRight;
    private float forwardSpeed;
    private float sideSpeed;
    private float jumpSpeed = 2.5f;
    private Vector3 speed;
    private float verticalVelocity = 0;
    private Camera cam;
    private int dreamCatched;
    private Animator playerAnimator;
    
    [SerializeField]
    private float movementSpeed = 2.5f;
    private bool isMovementEnabled = true;



    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerAnimator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        cam = Camera.main;
    }


    void Update() {
        MovingCharacter();
        AnimationOn();
    }

    private void MovingCharacter() {

        if (!isMovementEnabled) {
        return; // Do nothing if movement is disabled
        }

        characterRotationLeftRight = Input.GetAxis("Mouse X") * mouseSensivity;
        transform.Rotate(0, characterRotationLeftRight, 0); //Rotate whole character with camera view.

        forwardSpeed = Input.GetAxis("Vertical") * movementSpeed; // W, S
        sideSpeed = Input.GetAxis("Horizontal") * movementSpeed; // A, D

        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        if (characterController.isGrounded && Input.GetButtonDown("Jump")) { // SPACE
            verticalVelocity = jumpSpeed;
        }

        speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);
        speed = transform.rotation * speed; //  Moving towards camera view.
        characterController.Move(speed * Time.deltaTime);

    }

   


    void AnimationOn(){
        if(playerAnimator != null){

                movementSpeed = 2.5f;
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("WalkBackward");
                playerAnimator.ResetTrigger("WalkForward");
                playerAnimator.ResetTrigger("Run");

                playerAnimator.SetTrigger("Idle");

            if(Input.GetKey(KeyCode.W))
            {
                //Run
                if(Input.GetKey(KeyCode.LeftShift)){

                movementSpeed = 6f;
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("WalkBackward");
                playerAnimator.ResetTrigger("WalkForward");

                playerAnimator.SetTrigger("Run");
                }else{

                //Move
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("WalkBackward");
                playerAnimator.ResetTrigger("Run");

                playerAnimator.SetTrigger("WalkForward");}
                
            }

            if(Input.GetKey(KeyCode.S))
            {
                
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("WalkForward");
                playerAnimator.ResetTrigger("Run");

                playerAnimator.SetTrigger("WalkBackward");
            }

            if(Input.GetKey(KeyCode.A))
            {
                //Run
                if(Input.GetKey(KeyCode.LeftShift)){

                movementSpeed = 4f;
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("WalkBackward");
                playerAnimator.ResetTrigger("WalkForward");
                playerAnimator.ResetTrigger("Run");
                playerAnimator.ResetTrigger("RightRun");

                playerAnimator.SetTrigger("LeftRun");
                }else{

                //Move
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("WalkForward");
                playerAnimator.ResetTrigger("WalkBackward");
                playerAnimator.ResetTrigger("Run");
                playerAnimator.ResetTrigger("LeftRun");
                playerAnimator.ResetTrigger("RightRun");

                playerAnimator.SetTrigger("Left");
            }
            }

            if(Input.GetKeyUp(KeyCode.A))
            {
                movementSpeed = 2.5f;
            } 
            
            if(Input.GetKey(KeyCode.D))
            {
                //Run
                if(Input.GetKey(KeyCode.LeftShift)){

                movementSpeed = 4f;
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("WalkBackward");
                playerAnimator.ResetTrigger("WalkForward");
                playerAnimator.ResetTrigger("Run");
                playerAnimator.ResetTrigger("LeftRun");

                playerAnimator.SetTrigger("RightRun");
                }else{

                //Move
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("WalkForward");
                playerAnimator.ResetTrigger("WalkBackward");
                playerAnimator.ResetTrigger("Run");
                playerAnimator.ResetTrigger("LeftRun");
                playerAnimator.ResetTrigger("RightRun");

                playerAnimator.SetTrigger("Right");
            }
        }
        
    }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BadDream") || other.CompareTag("Boss"))
        {
            playerAnimator.ResetTrigger("Idle");
            playerAnimator.ResetTrigger("Left");
            playerAnimator.ResetTrigger("Right");
            playerAnimator.ResetTrigger("WalkForward");
            playerAnimator.ResetTrigger("WalkBackward");
            playerAnimator.ResetTrigger("Run");

            playerAnimator.SetTrigger("Punch");

            isMovementEnabled = false; // Disable movement when the player collides with the dream
            StartCoroutine(EnableMovementAfterDelay(0.7f)); // Re-enable movement after a delay of 0.7 seconds
    
            Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
            if (otherRigidbody != null) {
            otherRigidbody.velocity = Vector3.zero;
            }
            StartCoroutine(PunchCoroutine(other.gameObject, 0.7f));
             if (other.CompareTag("Boss")){dreamCatched = dreamCatched + 49;}
            // Destroy the dream and increase score
            dreamCatched++;
            Debug.Log(dreamCatched);
        }
    }

    IEnumerator PunchCoroutine(GameObject objectToDestroy, float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(objectToDestroy);
    }

    IEnumerator EnableMovementAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        isMovementEnabled = true;
    }

}
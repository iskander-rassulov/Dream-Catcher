using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   
    private CharacterController characterController;
    public float mouseSensivity = 2f;
    private float cameraUpDownRange = 60f;
    private float cameraRotationUpDown = 0;
    private float characterRotationLeftRight;
    private float forwardSpeed;
    private float sideSpeed;
    private float jumpSpeed = 2.5f;
    private Vector3 speed;
    private float verticalVelocity = 0;
    private Camera cam;
    private int score;
    private Animator playerAnimator;
    
    [SerializeField]
    private float movementSpeed = 2.5f;



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

                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("WalkBackward");
                playerAnimator.ResetTrigger("WalkForward");

                playerAnimator.SetTrigger("Idle");

            if(Input.GetKey(KeyCode.W))
            {
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("WalkBackward");

                playerAnimator.SetTrigger("WalkForward");
            }

            if(Input.GetKey(KeyCode.S))
            {
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("WalkForward");

                playerAnimator.SetTrigger("WalkBackward");
            }

            if(Input.GetKey(KeyCode.A))
            {
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Right");
                playerAnimator.ResetTrigger("WalkForward");
                playerAnimator.ResetTrigger("WalkBackward");

                playerAnimator.SetTrigger("Left");
            }

            if(Input.GetKey(KeyCode.D))
            {
                playerAnimator.ResetTrigger("Idle");
                playerAnimator.ResetTrigger("Left");
                playerAnimator.ResetTrigger("WalkForward");
                playerAnimator.ResetTrigger("WalkBackward");

                playerAnimator.SetTrigger("Right");
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dream"))
        {
            playerAnimator.ResetTrigger("Idle");
            playerAnimator.ResetTrigger("Left");
            playerAnimator.ResetTrigger("Right");

            playerAnimator.SetTrigger("Punch");

            StartCoroutine(PunchCoroutine(other.gameObject, 0.7f));
            // Destroy the dream and increase score
            score++;
        }
    }

    IEnumerator PunchCoroutine(GameObject objectToDestroy, float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(objectToDestroy);
    }

}
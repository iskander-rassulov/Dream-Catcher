using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int score = 0;
    public float speed = 20.0f;
    public float rotateSpeed = 2.0f;
    private Animator playerAnimator;
    private Rigidbody rb;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotateSpeed * Time.deltaTime);
        }
    }

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dream"))
        {
            // Destroy the dream and increase score
            Destroy(other.gameObject);
            score++;
        }
    }
}

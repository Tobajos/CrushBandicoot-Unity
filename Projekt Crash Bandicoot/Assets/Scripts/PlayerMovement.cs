﻿using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float firstJumpSpeed;
    public float secondJumpSpeed;
    public float jumpButtonGracePeriod;
    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    private bool isLanding = false;
    private DynamicBox[] boxes;

    private int maxJumpCount = 2;
    private int jumpsRemaining = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {

            boxes = FindObjectsOfType<DynamicBox>();

            
            foreach (DynamicBox box in boxes)
            {
                box.SetAttacking(true);
            }
            animator.SetBool("IsAttacking", true);


        }


        if (!Input.GetKey("e") && boxes != null) 
        {
            
            
            foreach (DynamicBox box in boxes)
            {
                box.SetAttacking(false);
            }
            animator.SetBool("IsAttacking", false);
        }



        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (ySpeed < 0)
        {

            ySpeed -= 0.05f;
            isLanding = true;
            animator.SetBool("IsDoubleJumping", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
           
            if (jumpsRemaining > 0)
            {
                jumpButtonPressedTime = Time.time;
                if (jumpsRemaining == maxJumpCount) 
                {
                    ySpeed = firstJumpSpeed; 
                }
                else 
                {
                    ySpeed = secondJumpSpeed; 
                    animator.SetBool("IsDoubleJumping", true);
                    

                }
                jumpsRemaining--; 
                animator.SetBool("IsJumping", true);
                

            }
        }


        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod && jumpButtonPressedTime != null)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = firstJumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
            }
        }
        else
        {
            characterController.stepOffset = 0;      
        }
        
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);


        if (characterController.isGrounded)
        {
            jumpsRemaining = maxJumpCount;
            lastGroundedTime = Time.time;
            animator.SetBool("IsJumping", false);

            if (isLanding)
            {

                isLanding = false; 
                animator.SetBool("IsLanding", false);
            }
        }

        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("IsMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

    }



}

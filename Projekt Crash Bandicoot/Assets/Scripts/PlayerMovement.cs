using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float firstJumpSpeed;
    public float secondJumpSpeed;
    public float jumpButtonGracePeriod;
    public Transform playerposition;
    private Animator animator;
    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;
    private Vector3 movementDirection;
    private bool isLanding = false;
    private DynamicBox[] boxes;
    public GameObject panel;
    private int maxJumpCount = 2;
    private int jumpsRemaining = 2;

    private EnemyAI Skeleton12;
    private EnemyAI Skeleton1;
    private EnemyAI Skeleton3;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        panel.SetActive(isActive);
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

            EnemyAI[] enemies = FindObjectsOfType<EnemyAI>();

            foreach (EnemyAI enemy in enemies)
            {
                enemy.setIsAttacking(true);
/*                if (enemy.gameObject.name == "Skeleton12")
                {
                    Skeleton12 = enemy;
                    Skeleton12.setIsAttacking(true);
                }
                else if (enemy.gameObject.name == "Skeleton1")
                {
                    Skeleton1 = enemy;
                    Skeleton1.setIsAttacking(true);
                }
                else if (enemy.gameObject.name == "Skeleton3")
                {
                    Skeleton3 = enemy;
                    Skeleton3.setIsAttacking(true);
                }    */       
            }
        }


        if (!Input.GetKey("e") && boxes != null) 
        {    
            foreach (DynamicBox box in boxes)
            {
                box.SetAttacking(false);
            }
            animator.SetBool("IsAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
            panel.SetActive(isActive);

            if (isActive)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
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
                soundManager.instance.PlayJumpSound();
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

    public void Knockback(Vector3 direction)
    {
        direction.y = 0;
        playerposition.position = playerposition.position+(direction * 10);
    }

}

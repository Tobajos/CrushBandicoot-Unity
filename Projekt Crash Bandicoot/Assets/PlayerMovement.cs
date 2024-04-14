using UnityEngine;

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
    private bool isAttacking = false;
    private DynamicBox dynamicBox;


    private int maxJumpCount = 2;
    private int jumpsRemaining = 2;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        dynamicBox = FindObjectOfType<DynamicBox>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("e"))
        {
            Debug.Log("Attacking");
            animator.SetBool("IsAttacking", true);
            isAttacking = true;
            dynamicBox.SetIsAttacking(true); // Przekaż informację o ataku do skryptu DynamicBox
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            isAttacking = false;
            dynamicBox.SetIsAttacking(false); // Przekaż informację o braku ataku do skryptu DynamicBox
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
                if (jumpsRemaining == maxJumpCount) // Pierwszy skok
                {
                    ySpeed = firstJumpSpeed; // Ustaw prędkość dla pierwszego skoku
                }
                else // Drugi skok
                {
                    ySpeed = secondJumpSpeed; // Ustaw prędkość dla drugiego skoku
                    animator.SetBool("IsDoubleJumping", true);
                    

                }
                jumpsRemaining--; // Zmniejsz liczbę pozostałych skoków
                animator.SetBool("IsJumping", true);
                

            }
        }


        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod && jumpButtonPressedTime != null)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;
            //animator.SetBool("IsLanding", true);
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
            //animator.SetBool("IsDoubleJumping", false);
            if (isLanding)
            {
                //animator.SetBool("IsLanding", true);
                isLanding = false; // Resetuj zmienną lądowania
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

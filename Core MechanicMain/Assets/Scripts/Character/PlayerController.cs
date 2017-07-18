using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public AudioClip healthSound, jump;

    //CONTROLLING THE CHARACTER
    public float walkSpeed = 2.3f;
    public float runSpeed = 6;
    public float gravity = -12;
    public float jumpHeight = 1;
    [Range(0,1)]
    public float airControlPercent;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;

    Animator animator;
    Transform cameraT;

    CharacterController controller;

    bool moveEnable;

    //FOR HEALTH
    [SerializeField]
    private Stat health;

    private void Awake()
    {
        health.Initialize();
    }

    void Start () {
        //CONTROLLING THE CHARACTER
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;

        controller = GetComponent<CharacterController>();

        moveEnable = true;

    }
	
	void Update () {
        if (moveEnable)
        {
            //CONTROLLING THE CHARACTER
            //input
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 inputDirection = input.normalized;

            bool running = Input.GetKey(KeyCode.LeftShift);

            Move(inputDirection, running);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }

            //animation
            float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
            animator.SetFloat("SpeedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

            //FOR HEALTH
            if (Input.GetKeyDown(KeyCode.Q))
            {
                health.CurrentValue -= 10;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                health.CurrentValue += 10;
            }
        }
    }

    public void IncreaseHealth(float amount)
    {
        AudioSource.PlayClipAtPoint(healthSound, transform.position, 0.8f);
        health.CurrentValue += amount;
    }


    void Move(Vector2 inputDirection, bool running)
    {
        if (inputDirection != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
        }

        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDirection.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

        velocityY += Time.deltaTime * gravity;

        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
        currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
        
        if (controller.isGrounded)
        {
            velocityY = 0;
        }

    }

    void Jump()
    {
        if (controller.isGrounded)
        {
            AudioSource.PlayClipAtPoint(jump, transform.position, 0.8f);
            float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
            velocityY = jumpVelocity;
        }
    }

    //SMOOTH TIME FOR ANIMATIONS
    float GetModifiedSmoothTime(float smoothTime)
    {
        if(controller.isGrounded)
        {
            return smoothTime;
        }

        if(airControlPercent == 0)
        {
            return float.MaxValue;
        }
        return smoothTime / airControlPercent;
    }

    public void EnableMove()
    {
        moveEnable = true;
    }

    public void DisableMove()
    {
        moveEnable = false;
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDirection = input.normalized;


        //Move(inputDirection, running);
        if (inputDirection != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
        }

        currentSpeed = 0;
        velocityY += Time.deltaTime * gravity;

        Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
   
        currentSpeed = 0;
        if (controller.isGrounded)
        {
            velocityY = 0;
        }



        //animation

        animator.SetFloat("SpeedPercent", 0, 0, Time.deltaTime);
    }

}

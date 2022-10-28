using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 direction;
    public float Speed;
    public float maxSpeed;

    private int desiredLine = 1;
    public float laneDistance = 2.5f;

    public float jumForce;
    public float gravity = -20;
    public Animator animator;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public bool isSliding = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted) return;

        characterController.Move(direction * Time.deltaTime);

        if(Speed < maxSpeed)
        {
            Speed += 0.1f * Time.deltaTime;
        }

        animator.SetBool("isGameStarted", true);
        animator.SetBool("isGrounded", isGrounded);
        direction.z = Speed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);

        if (isGrounded)
        {
            //direction.y = -1;
            if(SwipeManager.swipeUp) {
                Jump();
            }
        }else
        {
            direction.y += gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeDown && !isSliding)
        {
            StartCoroutine(Slide());
        }


        if (SwipeManager.swipeRight && desiredLine != 2)
        {
            desiredLine++;
        }

        if (SwipeManager.swipeLeft && desiredLine != 0)
        {
            desiredLine--;
        }

        Vector3 targerPositon = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLine == 0)
        {
            targerPositon += Vector3.left * laneDistance;
        }else if (desiredLine == 2)
        {
            targerPositon += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targerPositon, 80*Time.deltaTime);
    }

    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        characterController.center = new Vector3(0, -0.15f, 0);
        characterController.height = 1;

        yield return new WaitForSeconds(1.3f);

        animator.SetBool("isSliding", false);
        characterController.center = new Vector3(0, 0, 0);
        characterController.height = 2;
        isSliding = false;
    }

    private void Jump()
    {
        direction.y = jumForce;        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }
}

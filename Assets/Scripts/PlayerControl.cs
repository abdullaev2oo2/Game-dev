using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 direction;
    public float Speed;

    private int desiredLine = 1;
    public float laneDistance = 4;

    public float jumForce;
    public float gravity = -20;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = Speed;
        characterController.Move(direction * Time.deltaTime);

        if (characterController.isGrounded)
        {
            direction.y = -1;
            if(SwipeManager.swipeUp) {
                Jump();
            }
        }else
        {
            direction.y += gravity * Time.deltaTime;
        }
        

        if(SwipeManager.swipeRight && desiredLine != 2)
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

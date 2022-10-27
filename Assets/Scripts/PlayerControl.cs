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
        
        if(Input.GetKeyDown(KeyCode.RightArrow) && desiredLine != 2)
        {
            desiredLine++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && desiredLine != 0)
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

        // transform.position = targerPositon;
        transform.position = Vector3.Lerp(transform.position, targerPositon, 80*Time.deltaTime);
    }
}

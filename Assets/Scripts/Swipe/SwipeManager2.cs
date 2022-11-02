using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager2 : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    Vector2 direction;

    bool swipeRight, swipeLeft, swipeUp, swipeDown;
    bool oneTime;
    private void Update()
    {
        HandlePlayerMovement();
    }
    void HandlePlayerMovement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;

        }

        if(Input.GetMouseButtonUp(0))
        {   
            endPosition = Input.mousePosition;

            direction = endPosition - startPosition;

        }

        if(direction.x > 0)
        {
            if(direction.y > 0 && direction.y > direction.x)
            {
                swipeUp = true;
                swipeDown = swipeLeft = swipeRight = false;
                oneTime = true;
            }

            if (direction.y > 0 && direction.y < direction.x)
            {
                swipeRight = true;
                swipeDown = swipeLeft = swipeUp = false;
                oneTime = true;
            }
        }
        if (direction.x < 0)
        {
            if (direction.y < 0 && direction.y < direction.x)
            {
                swipeDown = true;
                swipeUp = swipeLeft = swipeRight = false;
                oneTime = true;
            }

            if (direction.y < 0 && direction.y > direction.x)
            {
                swipeLeft = true;
                swipeDown = swipeRight = swipeUp = false;
                oneTime = true;
            }
        } 
        if (direction.y > 0)
        {
            if (direction.x < 0 && direction.x < - direction.y)
            {
                swipeLeft = true;
                swipeUp = swipeDown = swipeRight = false;
                oneTime = true;
            }

            if (direction.x < 0 && direction.x > - direction.y)
            {
                swipeUp = true;
                swipeDown = swipeRight = swipeLeft = false;
                oneTime = true;
            }
        }
        if (direction.y < 0)
        {
            if (direction.x > 0 && direction.y > - direction.x)
            {
                swipeRight = true;
                swipeUp = swipeLeft = swipeDown = false;
                oneTime = true;
            }

            if (direction.x > 0 && direction.y < - direction.x)
            {
                swipeDown = true;
                swipeLeft = swipeRight = swipeUp = false;
                oneTime = true;
            }
        }
    }
}

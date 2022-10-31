using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    [SerializeField]
    private string StickTag;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(StickTag))
        {
            body.isKinematic = true;
        }else
        {
            body.useGravity = true;
        }

    }
    public void MoveWithVelocity(Vector3 Velocity)
    {
        body.velocity = Velocity;
    }
}

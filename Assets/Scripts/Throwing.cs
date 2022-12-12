using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing : MonoBehaviour
{
    [Header("References")]
    public Transform camera;
    public Transform attackPosition;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (SwipeManager.doubleTap)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(SwipeManager.startTouch);
            Debug.Log(ray);
            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (hit.collider.CompareTag("Obstacle"))
                {
                    Throw();
                    Destroy(bc.gameObject);
                }
            }
        }
    }

    public void Throw()
    {
        readyToThrow = false;

        GameObject projectile = Instantiate(objectToThrow, attackPosition.position, camera.rotation);

        Rigidbody projtileDb = projectile.GetComponent<Rigidbody>();

        Vector3 forceAdd = camera.transform.forward * throwForce + transform.up * throwUpwardForce;

        projtileDb.AddForce(forceAdd, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    public void ResetThrow()
    {
        readyToThrow = true;
    }
}
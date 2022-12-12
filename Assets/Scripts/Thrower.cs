using UnityEngine;

public class Thrower : MonoBehaviour
{
    //[SerializeField]
    //
    //private float FlightDurationInSeconds = 2;
    //
    //private Throwing Throwing;
    //
    //private Camera camera;
    //
    ////private bool _isShot;
    //
    //
    //// Start is called before the first frame update
    //void Start()
    //{
    //    camera = Camera.main;
    //}
    //
    //public void ChangeCurrentSpawn(Throwing NewSpawn)
    //{
    //    Throwing = NewSpawn;
    //    //_isShot = false;
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    if(SwipeManager.tap)
    //    {
    //
    //        RaycastHit hit;
    //        Ray ray = camera.ScreenPointToRay(SwipeManager.startTouch);
    //        if(Physics.Raycast(ray, out hit))
    //        {
    //            ShootWithVelocity(hit.point);
    //        }
    //    }
    //
    //}
    //
    //public void ShootWithVelocity(Vector3 TargetPosition)
    //{
    //    Throwing.MoveWithVelocity( (TargetPosition - Throwing.transform.position) / FlightDurationInSeconds);
    //}

    void Update()
    {
        if(SwipeManager.doubleTap)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(SwipeManager.startTouch);
            if(Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if(hit.collider.CompareTag("Obstacle"))
                {
                    Destroy(bc.gameObject);
                }
            }
        }
    }
}

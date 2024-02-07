using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{   Camera Camara;
    GameObject Target; Vector3 TargetPosition;
    public float CameraFollowSpeed;

    void CameraPositionActualization()
    {
        TargetPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, TargetPosition,Time.deltaTime*CameraFollowSpeed);
    }

    void Start()
    {
        Target = GameObject.Find("Rambird");
    }

    void Update()
    {
        CameraPositionActualization();     
        
    }
}

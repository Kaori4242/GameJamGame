using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject TargetObject;

    [SerializeField] float movingSpeed = 3f , offsetX  = 6 , offsetY = 4;


    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp( this.transform.position, new Vector3(TargetObject.transform.position.x + offsetX, TargetObject.transform.position.y - offsetY, this.transform.position.z ), movingSpeed * Time.fixedDeltaTime);
    }
}


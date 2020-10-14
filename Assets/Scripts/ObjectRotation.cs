using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public bool isItActive;
    public float rotationSpeed;

    public Transform nextPosition;
    public GameObject fullObject;

    public GameObject restart;

    public float tiltZmin;
    public float tiltZmax;
    public float tiltXmin;
    public float tiltXmax;
    private void FixedUpdate()
    {
        // Для ПК версии
        //float dirX = Input.GetAxisRaw("Horizontal");
        //float dirZ = Input.GetAxisRaw("Vertical");

        float dirX = SwipeGetter.instance.resultX;
        float dirZ = SwipeGetter.instance.resultY;

        if(transform.transform.localEulerAngles.z < 180)
            if (transform.transform.localEulerAngles.z >= tiltZmin && dirZ <= -1)
            dirZ = 0;
        if(transform.transform.localEulerAngles.z > 180)
            if (transform.transform.localEulerAngles.z <= tiltZmax && dirZ >= 1)
                dirZ = 0;
        if (transform.transform.localEulerAngles.x < 180)
            if (transform.transform.localEulerAngles.x >= tiltXmin && dirX <= -1)
                dirX = 0;
        if (transform.transform.localEulerAngles.x > 180)
            if (transform.transform.localEulerAngles.x <= tiltXmax && dirX >= 1)
                dirX = 0;

        if(Input.touchCount == 0)
        {
            SwipeGetter.instance.resultX = 0;
            SwipeGetter.instance.resultY = 0;
        }

        if (isItActive)
            transform.Rotate(-dirX /** rotationSpeed*/ * Time.fixedDeltaTime, 0, -dirZ /** rotationSpeed*/ * Time.fixedDeltaTime);
    }
}

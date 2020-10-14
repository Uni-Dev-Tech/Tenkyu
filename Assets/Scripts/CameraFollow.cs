using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objToFollow;
    private Vector3 deltaPos;
    private void Start()
    {
        deltaPos = transform.position - objToFollow.position;
    }
    private void Update()
    {
        transform.position = objToFollow.position + deltaPos;
    }
}

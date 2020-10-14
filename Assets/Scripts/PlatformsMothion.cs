using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsMothion : MonoBehaviour
{
    public GameObject platform_1, platform_2;
    public Transform nextPosition_1, nextPosition_2;
    private ObjectRotation obj_1, obj_2;
    private void Start()
    {
        obj_1 = platform_1.GetComponentInChildren<ObjectRotation>();
        obj_2 = platform_2.GetComponentInChildren<ObjectRotation>();
    }
    private void Update()
    {
        if (obj_1.isItActive)
        {
            platform_2.transform.position = nextPosition_1.position;
            obj_2.gameObject.transform.rotation = Quaternion.identity;
        }
        if (obj_2.isItActive)
        {
            platform_1.transform.position = nextPosition_2.position;
            obj_1.gameObject.transform.rotation = Quaternion.identity;
        }
    }
}

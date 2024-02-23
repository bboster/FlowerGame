using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsCamera : MonoBehaviour
{
    [SerializeField]
    bool lockX = true;

    [SerializeField]
    Vector3 offset = new Vector3(0, 180, 0);

    void LateUpdate()
    {
        //Vector3 rotation = Quaternion.LookRotation(Camera.main.transform.position).eulerAngles;
        //transform.rotation = Quaternion.Euler(rotation);
        transform.LookAt(Camera.main.transform);

        Vector3 newRotation = offset + transform.rotation.eulerAngles;
        if (lockX)
            newRotation.x = 0;

        transform.rotation = Quaternion.Euler(newRotation);
    }
}

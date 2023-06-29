using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    Vector3 offset = new Vector3 (-9.6f, 3.8f, -3.8f);
    void LateUpdate()
    {
        transform.position = playerPos.position + offset;
    }
}

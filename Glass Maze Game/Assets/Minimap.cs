using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform playerBody;



    void LateUpdate()
    {
        Vector3 newPosition = playerBody.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, playerBody.eulerAngles.y, 0f);
    }
}


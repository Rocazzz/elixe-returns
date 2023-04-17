using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Transform target; // el objeto que la cámara seguirá
    public float smoothSpeed; // la suavidad del seguimiento

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + new Vector3(0f, 2f, -40f); // la posición deseada de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // la posición suavizada de la cámara
        transform.position = smoothedPosition; // actualiza la posición de la cámara
    }
}

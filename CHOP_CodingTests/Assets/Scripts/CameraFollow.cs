using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothing = 50f;

    private Vector3 offset;

    void Awake()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCameraPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCameraPosition, Mathf.SmoothStep(0.0f, 100.0f, smoothing * Time.deltaTime));
    }

}

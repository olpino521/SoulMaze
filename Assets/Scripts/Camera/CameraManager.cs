using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float distance = 5f;
    [SerializeField] float fieldOfView = 5f;
    [SerializeField] float viewYOffset = 0.1f;

    Vector3 referenceDistance;
    float distanceFromPlayer;

    Camera mainReference;

    private void Awake()
    {
        FollowTarget();
    }
    private void Start()
    {
        mainReference = GetComponent<Camera>();
        mainReference.orthographic = true;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        distanceFromPlayer = (referenceDistance.normalized.x + referenceDistance.normalized.z) * distance + viewYOffset;
        mainReference.orthographicSize = fieldOfView;
        KeepRotation();
        FollowTarget();  
    }

    void FollowTarget()
    {
        float cameraHeight = target.position.y + Mathf.Sqrt(2 * distance * distance);
        float referenceZ = target.position.z - distance;
        float referenceX = target.position.x - distance;
        referenceDistance = new Vector3(referenceX, cameraHeight + viewYOffset, referenceZ);
        transform.position = referenceDistance;
    }

    void KeepRotation()
    {
        transform.eulerAngles = new Vector3(45, 45, 0);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}

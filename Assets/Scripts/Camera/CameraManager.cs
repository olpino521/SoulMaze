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

    private void Start()
    {
        mainReference = GetComponent<Camera>();
        mainReference.orthographic = true;
        referenceDistance = target.position - transform.position;  
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
        Vector3 followPosition = target.position - referenceDistance.normalized * distance;
        Vector3 followPositionFixed = new Vector3(followPosition.x, distanceFromPlayer, followPosition.z);
        transform.localPosition = followPositionFixed;
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

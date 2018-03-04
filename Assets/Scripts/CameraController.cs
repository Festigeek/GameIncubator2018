using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float dampTime = 0.2f;
    public float edgeBuffer = 4f;
    public float minDistance = 25;
    public Transform[] targets;

    private Camera cam;
    private float zoomSpeed;
    private Vector3 moveVelocity;
    private Vector3 desiredPosition;
    public float desiredDistance;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        //Move();
        Zoom();
        //transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
    }

    private void Move()
    {
        desiredPosition = DesiredPosition();

    }

    private Vector3 DesiredPosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        foreach (var target in targets)
        {
            if (!target.gameObject.activeSelf)
                continue;

            averagePos += target.position;
            numTargets++;
        }

        if (numTargets > 0)
            averagePos /= numTargets;

        averagePos.y = transform.position.y;

        return averagePos;
    }

    private void Zoom()
    {
        desiredDistance = DesiredDistance();

        Vector3 newPos = cam.transform.localPosition;
        newPos.y = Mathf.Max(minDistance, desiredDistance);
        cam.transform.position = newPos;
    }

    private float DesiredDistance()
    {
        float desiredWidth = 0f;
        float desiredHeight = 0f;

        foreach (var target in targets)
        {
            if (!target.gameObject.activeSelf)
                continue;

            Vector3 distanceToTarget = target.transform.position - transform.position;
            desiredWidth = (Mathf.Max(desiredWidth, distanceToTarget.x)) * 2;
            desiredHeight = (Mathf.Max(desiredWidth, distanceToTarget.z)) * 2;
        }

        return CalculateDistance(desiredWidth, desiredHeight);
    }

    private float CalculateDistance(float height, float width)
    {
        if (width / cam.aspect > height)
            height = width / cam.aspect;

        return height * 0.5f / Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Cinemachine.CinemachineTargetGroup targetGroup;

    public void AddTarget(Transform transform, float radius)
    {
        Cinemachine.CinemachineTargetGroup.Target target = new Cinemachine.CinemachineTargetGroup.Target();
        target.target = transform;
        target.weight = 1f;
        target.radius = radius;

        targetGroup.m_Targets.Add(target);
    }
}

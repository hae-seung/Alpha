using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSequenceOnly", menuName = "ScriptableObjects/CameraSequenceOnly", order = 1)]
public class CameraSequenceOnly : ScriptableObject
{
    [System.Serializable]
    public class CameraPoint
    {
        public Vector3 position;   // 위치
        public Quaternion rotation; // 회전
        public float duration;    // 머무는 시간
        public float cameraMoveSpeed;
        public float cameraRotateSpeed;
        public CameraOptions cameraOptions;
    }

    public CameraPoint[] cameraPoints; // 카메라 포인트 배열
}

public enum CameraOptions
{
    Move,
    Warp
}
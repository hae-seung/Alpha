using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSequenceOnlyController : MonoBehaviour
{
    public CameraSequenceOnly cameraSequenceOnly; // ScriptableObject 참조
    public float moveSpeed = 5f;

    private int currentPointIndex = 0;
    private float timer = 0f;
    private bool isMoving = false;

    
    /*
    void Start()
    {
        if (cameraSequenceOnly != null && cameraSequenceOnly.cameraPoints.Length > 0)
        {
            transform.position = cameraSequenceOnly.cameraPoints[0].position;
            transform.rotation = cameraSequenceOnly.cameraPoints[0].rotation;
            MoveToNextPoint();
        }
    }
    */

    void Update()
    {
        CheckAndMoveCamera();
    }
    
    void MoveToNextPoint()
    {
        currentPointIndex++;
        if (currentPointIndex >= cameraSequenceOnly.cameraPoints.Length)
        {
            isMoving = false; // 모든 포인트 도달
        }
        else
        {
            isMoving = true;
        }
    }
    
    public void PauseCameraMoving()
    {
        isMoving = false;
    }

    public void PlayCameraMoving()
    {
        isMoving = true;
    }

    public void StartCameraMoving()
    {
        currentPointIndex = 0;
        transform.position = cameraSequenceOnly.cameraPoints[0].position;
        transform.rotation = cameraSequenceOnly.cameraPoints[0].rotation;
        MoveToNextPoint();
    }

    void CheckAndMoveCamera()
    {
        if (!isMoving || cameraSequenceOnly == null) return;

        var currentPoint = cameraSequenceOnly.cameraPoints[currentPointIndex];

        // 카메라 이동
        if (currentPoint.cameraOptions == CameraOptions.Move)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, currentPoint.cameraMoveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, currentPoint.rotation, Time.deltaTime * currentPoint.cameraRotateSpeed);
        }
        else if (currentPoint.cameraOptions == CameraOptions.Warp)
        {
            transform.position = currentPoint.position;
            transform.rotation = currentPoint.rotation;
        }

        // 도착 체크
        if (Vector3.Distance(transform.position, currentPoint.position) < 0.1f)
        {
            timer += Time.deltaTime;
            if (timer >= currentPoint.duration)
            {
                timer = 0f;
                MoveToNextPoint();
            }
        }
    }
}

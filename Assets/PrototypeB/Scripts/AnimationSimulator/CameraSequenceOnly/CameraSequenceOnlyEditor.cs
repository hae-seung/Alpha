using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraSequenceOnly))]
public class CameraSequenceEditor : Editor
{
    private Transform dragTransform;

    public override void OnInspectorGUI()
    {
        // 기본 Inspector 표시
        base.OnInspectorGUI();

        // 드래그 앤 드롭 영역 표시
        GUILayout.Space(10);
        GUILayout.Label("Drag and Drop Transform to Add:");

        // 드래그 앤 드롭 영역 처리
        Event evt = Event.current;
        Rect dropArea = GUILayoutUtility.GetRect(0, 50, GUILayout.ExpandWidth(true));
        GUI.Box(dropArea, "Drop Transform Here", EditorStyles.helpBox);

        if (evt.type == EventType.DragUpdated || evt.type == EventType.DragPerform)
        {
            if (dropArea.Contains(evt.mousePosition))
            {
                DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                if (evt.type == EventType.DragPerform)
                {
                    DragAndDrop.AcceptDrag();
                    if (DragAndDrop.objectReferences.Length > 0)
                    {
                        foreach (Object obj in DragAndDrop.objectReferences)
                        {
                            if (obj is GameObject gameObject)
                            {
                                AddTransformToCameraSequence(gameObject.transform);
                            }
                        }
                    }
                    Event.current.Use();
                }
            }
        }
    }

    private void AddTransformToCameraSequence(Transform transform)
    {
        // CameraSequence 데이터 가져오기
        CameraSequenceOnly cameraSequence = (CameraSequenceOnly)target;
        if (cameraSequence == null) return;

        // 새 CameraPoint 생성 및 데이터 추가
        CameraSequenceOnly.CameraPoint newPoint = new CameraSequenceOnly.CameraPoint
        {
            position = transform.position,
            rotation = transform.rotation,
            duration = 2.0f, // 기본값
            cameraMoveSpeed = 1.0f,
            cameraRotateSpeed = 1.0f
        };

        // CameraPoint 배열 확장 및 데이터 저장
        ArrayUtility.Add(ref cameraSequence.cameraPoints, newPoint);

        // ScriptableObject 저장
        EditorUtility.SetDirty(cameraSequence);

        Debug.Log($"Added Transform '{transform.name}' to CameraSequence.");
    }
}
#endif
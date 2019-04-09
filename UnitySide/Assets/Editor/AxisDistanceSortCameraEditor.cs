using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

#if UNITY_EDITOR
[CustomEditor(typeof(AxisDistanceSortCameraHelper))]
public class AxisDistanceSortCameraEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //カメラのソートを設定する
        AxisDistanceSortCameraHelper cameraAxis = target as AxisDistanceSortCameraHelper;

        cameraAxis.SortAxis = EditorGUILayout.Vector3Field("ソート設定", cameraAxis.SortAxis);

//        EditorGUILayout.LabelField("ソート設定 X/Y/Z");
//        EditorGUILayout.BeginHorizontal();
//        cameraAxis.SortAxis_X = EditorGUILayout.FloatField(cameraAxis.SortAxis_X, GUILayout.Width(48.0f));
//        cameraAxis.SortAxis_Y = EditorGUILayout.FloatField(cameraAxis.SortAxis_Y, GUILayout.Width(48.0f));
//        cameraAxis.SortAxis_Z = EditorGUILayout.FloatField(cameraAxis.SortAxis_Z, GUILayout.Width(48.0f));
//        EditorGUILayout.EndHorizontal();
    }
}
#endif

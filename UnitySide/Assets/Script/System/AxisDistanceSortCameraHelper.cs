using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif    

[ExecuteInEditMode]
public class AxisDistanceSortCameraHelper : MonoBehaviour
{
    [SerializeField]
    private Vector3 cameraSortAxis = new Vector3(0.0f, 1.0f, -1.0f);

    /*
    [SerializeField]
    float cameraSortAxisX = 0.0f;
    [SerializeField]
    float cameraSortAxisY = 1.0f;
    [SerializeField]
    float cameraSortAxisZ = -1.0f;
    */

    void Start()
    {
        var camera = GetComponent<Camera>();
        camera.transparencySortMode = TransparencySortMode.CustomAxis;
//        camera.transparencySortAxis = new Vector3(cameraSortAxisX, cameraSortAxisY, cameraSortAxisZ);
        camera.transparencySortAxis = cameraSortAxis;

#if UNITY_EDITOR
        foreach (SceneView sv in SceneView.sceneViews)
        {
            sv.camera.transparencySortMode = TransparencySortMode.CustomAxis;
//            sv.camera.transparencySortAxis = new Vector3(cameraSortAxisX, cameraSortAxisY, cameraSortAxisZ);
            sv.camera.transparencySortAxis = cameraSortAxis;
        }
#endif      
    }

    public Vector3 SortAxis { get { return cameraSortAxis; } set { cameraSortAxis = value; } }

//    public float SortAxis_X { get { return cameraSortAxisX; } set { cameraSortAxisX = value; } }
//    public float SortAxis_Y { get { return cameraSortAxisY; } set { cameraSortAxisY = value; } }
//    public float SortAxis_Z { get { return cameraSortAxisZ; } set { cameraSortAxisZ = value; } }
}
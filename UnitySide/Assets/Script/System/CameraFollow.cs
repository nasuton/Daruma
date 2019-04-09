using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 startingPosition = Vector3.zero;

    [SerializeField]
    private Transform followTarget = null;

    private Vector3 targetPos = Vector3.zero;

    [SerializeField]
    private float moveSpeed = 0.0f;

    private void Initialize()
    {
        startingPosition = transform.position;
    }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        if(followTarget != null)
        {
            targetPos = new Vector3(followTarget.position.x, followTarget.position.y, transform.position.z);
            Vector3 velocity = (targetPos - transform.position) * moveSpeed;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);
        }
    }
}

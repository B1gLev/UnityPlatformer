using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float followDelay = 1f;
    [SerializeField] private float viewDistance = 7.5f;
    
    private Vector3 offset;
    private float lowY;
    private bool isFacingRigth;

    private void Start()
    {
        isFacingRigth = true;
        offset = transform.position - target.position;
        offset.x += viewDistance;
        lowY = transform.position.y;
    }

    private void FixedUpdate()
    {
        if (isFacingRigth != target.localScale.x > 0)
        {
            isFacingRigth = target.localScale.x > 0;
            offset.x += isFacingRigth ? viewDistance * 2 : -viewDistance * 2;
        }

        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.Lerp(
            transform.position, 
            targetPos, 
            followDelay * Time.deltaTime);

        if (transform.position.y < lowY)
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
    }
}

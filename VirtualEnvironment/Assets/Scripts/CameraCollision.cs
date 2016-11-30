using UnityEngine;
using System.Collections;

public class CameraCollision : MonoBehaviour
{
    [SerializeField]
    float setDistance;
    [SerializeField]
    LayerMask cameraCollision;
    Vector3 offset;

    void Start()
    {
        offset = new Vector3(0,0,0);
    }
    void Update()
    {
        Vector3 dir = (transform.position - transform.parent.position);
        Debug.DrawRay(transform.parent.position, dir, Color.red);
        Debug.DrawLine(Vector3.zero, transform.parent.position, Color.blue);
        Debug.DrawLine(Vector3.zero, transform.position, Color.green);
        var raycastHits = Physics.RaycastAll(transform.parent.position, dir, setDistance, cameraCollision);
        if (raycastHits.Length != 0)
        //if (Physics.Linecast(transform.parent.position, transform.parent.position + dir, out hit))
        //if (Physics.Linecast(transform.parent.position, transform.position, out hit))
        {
            float minDistance = Mathf.Infinity;
            foreach (RaycastHit h in raycastHits)
            {
                minDistance = Mathf.Min(minDistance, h.distance);
            }
            offset.z = -minDistance + .2f;
        }
        else
        {
            offset.z = -setDistance;
        }

        transform.localPosition = offset;
    }
}

using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collide");
        if (GlobalState.keyGrabbed)
        {
            transform.parent.gameObject.GetComponent<OpenDoorLerp>().OpenDoor();
        }
    }
}
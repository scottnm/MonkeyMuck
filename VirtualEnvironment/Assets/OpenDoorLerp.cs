using UnityEngine;
using System.Collections;

public class OpenDoorLerp : MonoBehaviour
{
    public void OpenDoor()
    {
        StartCoroutine(LerpDoorOpen());
    }

    IEnumerator LerpDoorOpen()
    {
        float rotSum = 0;
        while (rotSum < 90)
        {
            rotSum += 90 * Time.deltaTime;
            transform.Rotate(Vector3.up, -90 * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}

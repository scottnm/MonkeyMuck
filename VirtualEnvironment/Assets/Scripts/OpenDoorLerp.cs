using UnityEngine;
using System.Collections;

public class OpenDoorLerp : MonoBehaviour
{
    bool doorOpened = false;

    public void OpenDoor()
    {
        if (!doorOpened)
        {
            doorOpened = true;
            StartCoroutine(LerpDoorOpen());
        }
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

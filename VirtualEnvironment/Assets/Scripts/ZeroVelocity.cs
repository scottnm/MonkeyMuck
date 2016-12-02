using UnityEngine;
using System.Collections;

public class ZeroVelocity : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        var vel = col.gameObject.GetComponent<Rigidbody>().velocity;
        vel.x = 0;
        vel.z = 0;
        col.gameObject.GetComponent<Rigidbody>().velocity = vel;

        StartCoroutine(LerpToCenterOfTunnel(col.gameObject));
    }
    IEnumerator LerpToCenterOfTunnel(GameObject go)
    {
        float time = 0f;
        Vector3 posBuffer = new Vector3();

        float original_x = go.transform.position.x;
        float original_z = go.transform.position.z;

        while (time <= 1)
        {
            posBuffer.x = Mathf.Lerp(original_x, transform.position.x, time);
            posBuffer.y = go.transform.position.y;
            posBuffer.z = Mathf.Lerp(original_z, transform.position.z, time);

            go.transform.position = posBuffer;

            yield return new WaitForFixedUpdate();
            time += Time.deltaTime;
        }
        var vel = go.GetComponent<Rigidbody>().velocity;
        vel.x = 0;
        vel.z = 0;
        go.GetComponent<Rigidbody>().velocity = vel;
    }
}

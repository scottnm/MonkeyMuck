using UnityEngine;
using System.Collections;

namespace Filibusters
{
    public class ZeroVelocity : MonoBehaviour
    {
        void OnTriggerEnter(Collider col)
        {
            var vel = col.gameObject.GetComponent<Rigidbody>().velocity;
            vel.x = 0;
            vel.z = 0;
            col.gameObject.GetComponent<Rigidbody>().velocity = vel;
        }
    }
}

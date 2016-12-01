using UnityEngine;
using System.Collections;

namespace Filibusters
{
    public class RotateMonkeyMuckRing : MonoBehaviour
    {
        [SerializeField]
        float rotateSpeed;

        void Update()
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }
}

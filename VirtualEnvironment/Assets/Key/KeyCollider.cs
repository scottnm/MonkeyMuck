using UnityEngine;
using System.Collections;

public class KeyCollider : MonoBehaviour
{
    void OnTriggerEnter()
    {
        GlobalState.keyGrabbed = true;
        Object.Destroy(gameObject);
        AudioManager.Instance.PlayKeyCollect();
    }
}
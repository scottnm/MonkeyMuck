using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MonkeyMuckSpawner : MonoBehaviour
{
    [SerializeField] float SpawnDelay;
    [SerializeField] LayerMask haltSpawnerOnIntersection;
    [SerializeField] float playerDetectionRadius;
    HashSet<GameObject> mFree;
    HashSet<GameObject> mInUse;

    public void Despawn(GameObject monkeyMuckToDespawn)
    {
        UnityEngine.Assertions.Assert.IsTrue(mInUse.Contains(monkeyMuckToDespawn));
        monkeyMuckToDespawn.SetActive(false);
        monkeyMuckToDespawn.transform.localPosition = Vector3.zero;
        mInUse.Remove(monkeyMuckToDespawn);
        mFree.Add(monkeyMuckToDespawn);
    }

    void Start()
    {
        mFree = new HashSet<GameObject>();
        mInUse = new HashSet<GameObject>();

        foreach (Transform child in transform)
        {
            mFree.Add(child.gameObject);
        }
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            var playerNotClose = Physics.OverlapSphere(transform.position, playerDetectionRadius, haltSpawnerOnIntersection).Length == 0;
            if (mFree.Count > 0 && playerNotClose)
            {
                var nextMuck = popFree();
                nextMuck.SetActive(true);
                mInUse.Add(nextMuck);
            }
            yield return new WaitForSeconds(SpawnDelay);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, playerDetectionRadius);
    }

    GameObject popFree()
    {
        var itr = mFree.GetEnumerator();
        itr.MoveNext();
        var go = itr.Current;
        mFree.Remove(go);
        return go;
    }
}
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MonkeyMuckSpawner : MonoBehaviour
{
    [SerializeField] float SpawnDelay;
    [SerializeField] LayerMask haltSpawnerOnIntersection;
    [SerializeField] float playerDetectionRadius;
    [SerializeField] GameObject[] Destinations;

    HashSet<GameObject> mFree;
    HashSet<GameObject> mInUse;

    int nextDestinationIndex;

    public void Despawn(GameObject monkeyMuckToDespawn)
    {
        UnityEngine.Assertions.Assert.IsTrue(mInUse.Contains(monkeyMuckToDespawn));
        monkeyMuckToDespawn.SetActive(false);
        monkeyMuckToDespawn.transform.localPosition = Vector3.zero;
        mInUse.Remove(monkeyMuckToDespawn);
        mFree.Add(monkeyMuckToDespawn);
        nextDestinationIndex = 0;
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
                nextMuck.GetComponent<WalkToDestination>().Destination = Destinations[(nextDestinationIndex++) % Destinations.Length];
                nextMuck.SetActive(true);
                mInUse.Add(nextMuck);
            }
            yield return new WaitForSeconds(SpawnDelay);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
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
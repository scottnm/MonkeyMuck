using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MonkeyMuckSpawner : MonoBehaviour
{
    [SerializeField] float SpawnDelay;
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
            var playerNotClose = true;
            if (mFree.Count > 0 && playerNotClose)
            {
                var nextMuck = popFree();
                nextMuck.SetActive(true);
                mInUse.Add(nextMuck);
            }
            yield return new WaitForSeconds(SpawnDelay);
        }
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
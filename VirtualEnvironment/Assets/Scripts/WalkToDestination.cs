using UnityEngine;
using System.Collections;

public class WalkToDestination : MonoBehaviour
{
    public GameObject Destination { get; set; }
    UnityEngine.AI.NavMeshAgent InternalNavMeshAgent;
    MonkeyMuckSpawner Spawner;

    // Use this for initialization
    void Start()
    {
        InternalNavMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Spawner = transform.parent.gameObject.GetComponent<MonkeyMuckSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        //////////////////////////////////////////////////////////////////////////////////////////
        //You don't have to include this one line code:
        //I included this line to correct my enemy's rotation, you might not need this one line.
        //Or you may have to change the rotation to fit your character.
        //gameObject.transform.Rotate(270, 0, 0);
        //////////////////////////////////////////////////////////////////////////////////////////

        InternalNavMeshAgent.SetDestination(Destination.transform.position);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == Destination)
        {
            Spawner.Despawn(gameObject);
        }
    }
}
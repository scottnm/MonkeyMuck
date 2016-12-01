using UnityEngine;
using System.Collections.Generic;

namespace Filibusters
{
    public class Warphole : MonoBehaviour
    {
        [SerializeField] int warpCount;
        Dictionary<GameObject, int> WarpCounts;

        void Start()
        {
            WarpCounts = new Dictionary<GameObject, int>();
        }

        void OnTriggerEnter(Collider col)
        {
            var go = col.gameObject;
            int count;

            if (WarpCounts.ContainsKey(go))
            {
                count = WarpCounts[go];
            }
            else
            {
                WarpCounts[go] = 0;
                count = 0;
            }

            WarpCounts[go] = ++count;

            if (count <= warpCount)
            {
                var goPos = go.transform.position;
                goPos.y = transform.position.y;
                go.transform.position = goPos;
            }
            else
            {
                WarpCounts[go] = 0;
            }
        }
    }
}

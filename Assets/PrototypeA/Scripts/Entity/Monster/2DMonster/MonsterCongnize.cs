using System;
using UnityEngine;

public class MonsterCongnize : MonoBehaviour
{
    [SerializeField] private float radius = 3f; 
    [SerializeField] private LayerMask detectionLayer; 
    
    private Collider2D[] results = new Collider2D[50];

    public bool IsFindTarget { get; private set; }
    
    private void Awake()
    {
        IsFindTarget = false;
    }

    public void CongnizePlayer()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, radius, results, detectionLayer);

        if (count == 0)
        {
            IsFindTarget = false;
        }
        else
        {
            if (count == results.Length)
            {
                Collider2D[] allResults = Physics2D.OverlapCircleAll(transform.position, radius, detectionLayer);

                foreach (Collider2D collider in allResults)
                {
                    if (collider.CompareTag("Player"))
                    {
                        IsFindTarget = true;
                        return;
                    }
                }
                
                IsFindTarget = false;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Collider2D collider = results[i];
                    if (collider.CompareTag("Player"))
                    {
                        IsFindTarget = true;
                        return;
                    }
                }

                IsFindTarget = false;
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
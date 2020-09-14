using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCAI : MonoBehaviour
{
    public GameObject destinationPoint;
    NavMeshAgent theAgent;

    private void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        theAgent.SetDestination(destinationPoint.transform.position);
    }
}

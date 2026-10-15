using System;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.AI;

public class MechUnit : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private NavMeshAgent navMeshAgent;


    public void MoveToTarget(Vector3 toTarget)
    {
        navMeshAgent.SetDestination(toTarget);
    }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveToTarget(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using UnityEngine;
using UnityEngine.AI;

public class MechUnit : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private ObjectTeam  _team = ObjectTeam.Player;


    public void MoveToTarget(Vector3 toTarget)
    {
        _navMeshAgent.SetDestination(toTarget);
    }
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    

}

using UnityEngine;
using UnityEngine.AI;

public class MechUnit : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private GameObject _selectedRing;

    public void MoveToTarget(Vector3 toTarget)
    {
        _navMeshAgent.SetDestination(toTarget);
    }
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    public void SetSelectedUnit(bool on)
    {
        _selectedRing.SetActive(on);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

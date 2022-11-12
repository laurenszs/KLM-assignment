using UnityEngine;
using UnityEngine.AI;

public class PlaneUtils : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Transform _target;
    private NavMeshAgent _agent;
    private float _timer;

    public bool park;

    // Use this for initialization
    private void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();
        _timer = wanderTimer;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!park)
        {
            _timer += Time.deltaTime;
            if (_timer >= wanderTimer)
            {
                var newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                _agent.SetDestination(newPos);
                _timer = 0;
            }
        }
    }

    private static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        var randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
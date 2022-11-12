using UnityEngine;
using UnityEngine.AI;

public class PlaneUtils : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public bool park;
    
    [SerializeField] private AirPlaneScriptable planeScriptable;
    
    private Transform _target;
    private NavMeshAgent _agent;
    private float _timer;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _timer = wanderTimer;

        ApplyPrefab();
    }

    private void ApplyPrefab()
    {
        name = $"{planeScriptable.brand.ToString()} {planeScriptable.type.ToString()}";
        var children = GetComponentsInChildren<MeshRenderer>();
        foreach (var mRenderer in children) //set material to all renderers on plane
        {
            mRenderer.material = planeScriptable.planeMaterial;
        }
    }

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

    //generates target for navmesh to go to
    private static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        var randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
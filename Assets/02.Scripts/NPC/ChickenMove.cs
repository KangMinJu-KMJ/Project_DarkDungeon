using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ChickenMove : MonoBehaviour
{
    [SerializeField]
    private List<Transform> wayPoints;
    public int nexIdx;
    private NavMeshAgent agent;

    private readonly float moveSpeed = 0.5f;
    private float damping = 1.0f;
    private Transform chickenTr;
    private bool _patrolling;


    public float speed
    {
        get { return agent.velocity.magnitude; }
    }

    void Start()
    {
        chickenTr = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.updateRotation = false;
        agent.speed = moveSpeed;
        var group = GameObject.Find("ChickenPlace");
        if(group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
        }
        MoveWayPoint();
    }

    void MoveWayPoint()
    {
        if (agent.isPathStale) return;
        agent.destination = wayPoints[nexIdx].position;
        agent.isStopped = false;
        _patrolling = true;
    }

    void Update()
    {
        if(agent.isStopped == false)
        {
            Quaternion rot = Quaternion.LookRotation(agent.desiredVelocity);
            chickenTr.rotation = Quaternion.Slerp(chickenTr.rotation, rot,
                                                    Time.deltaTime * damping);
        }

        if (!_patrolling)
        {
            return;
        }
        
        
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f &&
              agent.remainingDistance <= 0.5f)
        {
            nexIdx = Random.Range(0, wayPoints.Count);
            MoveWayPoint();
        }
    }
}

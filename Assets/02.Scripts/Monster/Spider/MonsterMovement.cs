using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField]
    private List<Transform> wayPoints;
    private int nexIdx;
    private NavMeshAgent agent;

    private readonly float patrolSpeed = 1.5f;
    private readonly float traceSpeed = 3.0f;
    private float damping = 1.0f;
    private Transform enemyTr;
    private bool _patrolling;

    public bool patrolling
    {
        get { return _patrolling; }
        set
        {
            _patrolling = value;
            if(_patrolling)
            {
                agent.speed = patrolSpeed;
                damping = 1.0f;
                MoveWayPoint();
            }
        }
    }

    private Vector3 _traceTarget;
    public Vector3 traceTarget
    {
        get { return _traceTarget; }
        set
        {
            _traceTarget = value;
            agent.speed = traceSpeed;
            damping = 7.0f;
            TraceTarget(_traceTarget);
        }
    }

    public float speed
    {
        get { return agent.velocity.magnitude; }
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyTr = GetComponent<Transform>();
        agent.autoBraking = false;
        agent.updateRotation = false;
        agent.speed = patrolSpeed;
        var group = GameObject.Find("SpiderMovingPoint");
        if(group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
            nexIdx = Random.Range(0, wayPoints.Count);
        }
        MoveWayPoint();
    }

    
    void Update()
    {
        if(agent.isStopped == false)
        {
            Quaternion rot = Quaternion.LookRotation(agent.desiredVelocity);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);
        }
        if (!patrolling) return;
        //Debug.Log(agent.remainingDistance);
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f &&
            agent.remainingDistance <= 0.5f)
        {
            nexIdx = Random.Range(0, wayPoints.Count);
            MoveWayPoint();
        }
        
    }

    void MoveWayPoint()
    {
        if (agent.isPathStale) return;
        agent.destination = wayPoints[nexIdx].position;
        agent.isStopped = false;
    }

    void TraceTarget(Vector3 pos)
    {
        if (agent.isPathStale) return;
        agent.destination = pos;
        agent.isStopped = false;
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        _patrolling = false;
    }
}

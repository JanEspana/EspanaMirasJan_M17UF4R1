using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
    NavMeshAgent agent;
    internal float distance = 10;
    bool currentNode = false;
    public float speed;
    public List<GameObject> nodes;
    public BehaviourTree behaviourTree;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        behaviourTree.Execute(this);
    }
    public void ChaseTarget(Transform target, Transform self)
    {
        agent.speed = speed;
        agent.SetDestination(target.position);
    }

    public void ChaseNodes()
    {
        agent.speed = speed;
        if (agent.remainingDistance == 0)
        {
            Debug.Log("Reached Node");
            currentNode = !currentNode;
            agent.SetDestination(currentNode ? nodes[1].transform.position : nodes[0].transform.position);
        }
    }
}

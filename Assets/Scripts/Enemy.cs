using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamage
{
    public GameObject player;
    Rigidbody rb;
    internal NavMeshAgent agent;
    internal float distance = 10;
    bool currentNode = false;
    public float speed, maxHP = 10;
    public List<GameObject> nodes;
    public BehaviourTree behaviourTree;
    public float HP { get; set; }

    void Awake()
    {
        HP = maxHP;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        behaviourTree.Execute(this);
    }
    public void Chase(Transform target, Transform self)
    {
        Debug.Log("Voy por ti joputa");
        agent.speed = speed;
        agent.SetDestination(target.position);
    }

    public void Patrol()
    {
        agent.speed = speed;
        if (agent.remainingDistance == 0)
        {
            Debug.Log("Patrullando la ciudad");
            currentNode = !currentNode;
            agent.SetDestination(currentNode ? nodes[1].transform.position : nodes[0].transform.position);
        }
    }

    public void Escape(Transform target)
    {
        Debug.Log("Ayuda Diosito");
        agent.speed = speed * 1.25f;
        agent.SetDestination(transform.position + (transform.position - target.position));
    }
    public void ConfusedPatrol()
    {
        Debug.Log("Huh");
        agent.speed = speed;
        StartCoroutine(SetNewPointRandom());

    }
    IEnumerator SetNewPointRandom()
    {
        yield return new WaitForSeconds(2);
        agent.SetDestination(transform.position + new Vector3(Random.Range(0, 2) == 0 ? -3 : 3, 0, Random.Range(0, 2) == 0 ? -3 : 3));
    }
    public void TakeDamage(float dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
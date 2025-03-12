using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FollowSO", menuName = "NodesSO/FollowSO", order = 1)]
public class FollowSO : NodeSO
{
    public override bool Execute(Enemy enemy)
    {
        if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) <= enemy.distance)
        {
            RaycastHit hit;
            if (Physics.Raycast(enemy.transform.position, enemy.player.transform.position - enemy.transform.position, out hit))
            {
                //si detecta al jugador y no hay obstaculos entre ellos, persigue al jugador
                if (hit.transform.CompareTag("Player"))
                {
                    enemy.ChaseTarget(enemy.player.transform, enemy.transform);
                    return true;
                }
            }
        }
        return false;
    }
}

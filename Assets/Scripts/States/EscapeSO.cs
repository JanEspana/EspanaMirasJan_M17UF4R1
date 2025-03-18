using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EscapeSO", menuName = "NodesSO/EscapeSO", order = 1)]
public class EscapeSO : NodeSO
{
    public override bool Execute(Enemy enemy)
    {
        if (enemy.HP < enemy.maxHP / 2)
        {
            if (Vector3.Distance(enemy.transform.position, enemy.player.transform.position) <= enemy.distance)
            {
                RaycastHit hit;
                if (Physics.Raycast(enemy.transform.position, enemy.player.transform.position - enemy.transform.position, out hit))
                {

                    //mira si el jugador esta cerca y si no hay obstaculos entre el enemigo y el jugador
                    if (hit.transform.CompareTag("Player"))
                    {
                        enemy.RunAway(hit.transform);
                        return true;
                    }
                }
            }
        }
        return false;
    }
}

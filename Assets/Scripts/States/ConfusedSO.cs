using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConfusedSO", menuName = "NodesSO/ConfusedSO", order = 1)]
public class ConfusedSO : NodeSO
{
    public override bool Execute(Enemy enemy)
    {
        if (enemy.HP < enemy.maxHP)
        {
            enemy.ConfusedPatrol();
            return true;
        }
        return false;
    }
}
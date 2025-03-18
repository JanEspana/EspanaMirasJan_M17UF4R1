using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PatrolSO", menuName = "NodesSO/PatrolSO", order = 1)]
public class PatrolStateSO : NodeSO
{
    public override bool Execute(Enemy enemy)
    {
        enemy.Patrol();
        return true;
    }
}

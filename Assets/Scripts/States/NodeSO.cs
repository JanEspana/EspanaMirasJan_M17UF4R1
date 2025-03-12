using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NodeSO", menuName = "NodesSO/FollowSO", order = 1)]
public abstract class NodeSO : ScriptableObject
{
    public abstract bool Execute(Enemy enemy);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "BehaviourTree", menuName = "NodesSO/BehaviourTree", order = 1)]
public class BehaviourTree : NodeSO
{
    public List<NodeSO> nodes = new List<NodeSO>();
    public NodeSO root;

    public override bool Execute(Enemy enemy)
    {
        nodes = nodes.OrderBy(x => x.priority).ToList();
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].Execute(enemy))
            {
                return true;
            }
        }
        return false;
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SONode", menuName = "Scriptable Objects/SONode")]
public class SONode : ScriptableObject
{
    public List<SONode> Children;
    public virtual bool StartCondition(Enemy enemy) => true;
    public virtual bool EndCondition(Enemy enemy) => true;
    public virtual void OnStart(Enemy enemy) { }
    public virtual void OnUpdate(Enemy enemy)
    {
        if (EndCondition(enemy))
            enemy.ChangeNode();
    }
    public virtual void OnEnd(Enemy enemy) { }
}

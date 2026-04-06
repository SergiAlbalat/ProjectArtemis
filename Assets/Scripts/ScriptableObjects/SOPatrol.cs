using UnityEngine;

[CreateAssetMenu(fileName = "SOPatrol", menuName = "Scriptable Objects/SOPatrol")]
public class SOPatrol : SONode
{
    public override bool StartCondition(Enemy enemy) => true;
    public override bool EndCondition(Enemy enemy) => enemy.run.GetCheck();
    public override void OnStart(Enemy enemy) { }
    public override void OnUpdate(Enemy enemy)
    {
        base.OnUpdate(enemy);
        enemy.SetPatrolDestination();
    }
    public override void OnEnd(Enemy enemy) { }
}

using UnityEngine;

[CreateAssetMenu(fileName = "SORun", menuName = "Scriptable Objects/SORun")]
public class SORun : SONode
{
    public override bool StartCondition(Enemy enemy) => enemy.run.GetCheck();
    public override bool EndCondition(Enemy enemy) => enemy.die.GetCheck() || !enemy.run.GetCheck();
    public override void OnStart(Enemy enemy) { }
    public override void OnUpdate(Enemy enemy)
    {
        base.OnUpdate(enemy);
        enemy.RunUpdate();
    }
    public override void OnEnd(Enemy enemy) { }
}

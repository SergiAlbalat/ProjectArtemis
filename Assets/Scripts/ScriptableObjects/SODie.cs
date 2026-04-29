using UnityEngine;

[CreateAssetMenu(fileName = "SODie", menuName = "Scriptable Objects/SODie")]
public class SODie : SONode
{
    public override bool StartCondition(Enemy enemy) => enemy.die.GetCheck();
    public override bool EndCondition(Enemy enemy) => false;
    public override void OnStart(Enemy enemy)
    {
        enemy.StartCapture();
    }
    public override void OnUpdate(Enemy enemy) { }
    public override void OnEnd(Enemy enemy) { }
}

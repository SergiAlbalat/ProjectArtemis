using UnityEngine;

[CreateAssetMenu(fileName = "SODie", menuName = "Scriptable Objects/SODie")]
public class SODie : SONode
{
    public override bool StartCondition(Enemy enemy) => enemy.die.GetCheck();
    public override bool EndCondition(Enemy enemy) => false;
    public override void OnStart(Enemy enemy)
    {
        GameManager.gm.CaptureEnemy(enemy.enemyData);
    }
    public override void OnUpdate(Enemy enemy) { }
    public override void OnEnd(Enemy enemy) { }
}

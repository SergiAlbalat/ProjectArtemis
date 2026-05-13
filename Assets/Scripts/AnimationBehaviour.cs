using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    public Animator animator;
    public void PlayerMove(float velocity, bool battleMode)
    {
        animator.SetFloat("Velocity", velocity);
        animator.SetBool("Battle", battleMode);
    }
    public void PlayerStun()
    {
        animator.SetTrigger("Stun");
    }
    public void PlayerAttack()
    {
        animator.SetTrigger("Attack");
    }
    public void PlayerRight(bool option)
    {
        animator.SetBool("Right", option);
    }
    public void PlayerLeft(bool option)
    {
        animator.SetBool("Left", option);
    }
    public void EnemyCaptured(bool option)
    {
        animator.SetBool("Captured", option);
    }
    public void EnemyStunned(bool option)
    {
        animator.SetBool("Stunned", option);
    }
    public void EnemyColapsing()
    {
        animator.SetBool("Colapsing", true);
    }
}

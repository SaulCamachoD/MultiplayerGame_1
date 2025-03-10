using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public Animator animator;

    public void RunAnimation(bool isRunning)
    {
        animator.SetBool("Run", isRunning);
    }

    public void ShootAnimation()
    {
        animator.SetTrigger("Shoot");
    }
}

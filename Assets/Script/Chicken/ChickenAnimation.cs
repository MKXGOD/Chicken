using UnityEngine;

public class ChickenAnimation
{
    private Animator _animator;
    public ChickenAnimation(Animator animator)
    { 
        _animator = animator;
    }

    public void RunAnimation(Vector3 moveVector)
    {
        if (moveVector.x != 0 || moveVector.z != 0)
        {
            _animator.SetBool("Walk", true);
        }
        else _animator.SetBool("Walk", false);
    }
    public void AttackAnimation()
    {
        _animator.Play("Eat");
    }
    public void TurnHeadAnimation()
    {
        _animator.SetTrigger("TurnHead");
    }
}

using UnityEngine;

public class ChickenAnimation : MonoBehaviour
{
    [SerializeField] private ChickenController _controller;

    public Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RunAnimation();
    }
    public void RunAnimation()
    {

        if (_controller._moveVector.x != 0 || _controller._moveVector.z != 0)
            Animator.SetBool("Walk", true);
        else
            Animator.SetBool("Walk", false);

    }
    public void AttackAnimation()
    {
        Animator.Play("Eat");
    }
    public void TurnHead()
    {
        Animator.SetTrigger("Turn Head");
    }
}

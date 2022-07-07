using UnityEngine;

public class DogAnimator : MonoBehaviour
{
    private Animator _animator;
    private Mover _mover;
    private const string Jump = "Jump";

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();

        _mover.JumpButtonPressed += ActivateRun;
    }

    private void OnDisable()
    {
        _mover.JumpButtonPressed -= ActivateRun;
    }
    
    private void ActivateRun()
    {
        _animator.SetTrigger(Jump);
    }
}

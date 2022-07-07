using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(StickmanAnimator))]
public class Stickman : MonoBehaviour
{
    private StickmanAnimator _stickmanAnimator;
    private BoxCollider _collider;
    private Animator _animator;

    public event UnityAction BranchTouched;

    public void ChangeAnimation()
    {
        _stickmanAnimator.Move();
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<BoxCollider>();
        _stickmanAnimator = GetComponent<StickmanAnimator>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out BranchFragment fragment))
        {
            _animator.enabled = false;
            _collider.enabled = false;

            BranchTouched?.Invoke();
            
            _stickmanAnimator.StopMove();
        }
    }
}

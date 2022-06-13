using UnityEngine;
using DG.Tweening;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [Space]
    [Range(1, 20)] [SerializeField] private int _duration;
    [Range(1, 100)] [SerializeField] private int _offset;

    private const string Speed = "Speed";
    private int _speed = 1;
    
    
    public void Move()
    {
        ChangeAnimation();
        Walk();
    }

    private void Walk()
    {
        transform.DOMoveZ(transform.position.z - _offset, _duration).SetEase(Ease.Linear);
    }

    private void ChangeAnimation()
    {
        _animator.SetInteger(Speed,_speed);
    }
}

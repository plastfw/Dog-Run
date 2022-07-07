using System.Diagnostics;
using UnityEngine;
using DG.Tweening;

public class StickmanAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [Space]
    [Range(1, 20)] [SerializeField] private int _duration;
    [Range(1, 100)] [SerializeField] private int _offset;
    [Space] 
    [SerializeField] private Stickman _stickman;

    private const string Speed = "Speed";
    private const int _speed = 1;

    private Tween _walk;
    
    private void OnEnable()
    {
        _stickman = GetComponent<Stickman>();
    }
    
    public void Move()
    {
        ChangeAnimation();
        Walk();
    }
    
    public void StopMove()
    {
        _walk.Kill();
    }
    
    private void Walk()
    {
        _walk = transform.DOMoveZ(transform.position.z - _offset, _duration).SetEase(Ease.Linear);
    }
    
    private void ChangeAnimation()
    {
        _animator.SetInteger(Speed,_speed);
    }

}

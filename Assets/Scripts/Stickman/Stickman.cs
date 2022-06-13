using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField]
    private AnimationController _animationController;
    
    private void Start()
    {
        _animationController = GetComponent<AnimationController>();
    }

    public void ChangeAnimation()
    {
        _animationController.Move();
    }
}
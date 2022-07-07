using UnityEngine;
using DG.Tweening;

public class Animation360 : MonoBehaviour
{
    [SerializeField] private float _duration = 0.3f;

    private Vector3 _rotation = new Vector3(-360, 0, 0);
    
    private void Start()
    {
        transform.DORotate(_rotation, _duration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }
}

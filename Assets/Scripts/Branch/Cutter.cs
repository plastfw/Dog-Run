using System.Collections;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Branch))]
public class Cutter : MonoBehaviour
{
    [SerializeField] private Transform _rightPoint;
    [SerializeField] private Transform _leftPoint;
    [SerializeField] private float _step = 0.1f;

    private float _maxSize = 2f;
    private float _minSize = 0.1f;
    private Branch _branch;
    
    private void OnEnable()
    {
        _branch = GetComponent<Branch>();
        _branch.Cut += CutLogic;
    }

    private void OnDisable()
    {
        _branch.Cut -= CutLogic;
    }

    private void CutLogic(Transform cutPoint)
    {
        var position = cutPoint.position;
        
        var distanceLeft = Vector3.Distance(position,_leftPoint.transform.position);
        var distanceRight = Vector3.Distance(position, _rightPoint.transform.position);
        
        if (!(transform.localScale.x > _minSize) || transform.localScale.x == _minSize) 
            return;

        if (distanceLeft < distanceRight)
        {
            var cor=  StartCoroutine(Cut(cutPoint, _leftPoint));
        }
        else
        {
            var cor=  StartCoroutine(Cut(cutPoint, _rightPoint));
        }
    }

    private IEnumerator Cut(Transform cutPosition,Transform point)
    {
        while (Vector3.Distance(point.transform.position, cutPosition.position) > 0)
        {
            transform.DOScaleX(transform.localScale.x - _step, 0.2f);
            
            yield return null;
        }

    }

    private void Increase()
    {
        if (transform.localScale.x < _maxSize)
        {
            
        }
    }
}
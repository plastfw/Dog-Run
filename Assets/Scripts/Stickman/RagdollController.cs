using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _rigidbodies;
    [SerializeField] private List<Rigidbody> _rigidbodiesForPunch;

    private Stickman _stickman;
    
    private float _punchDuration = 0.2f;

    private Vector3 offset = new Vector3(0, 1f, 1f);

    private void OnEnable()
    {
        _stickman = GetComponent<Stickman>();
        _stickman.BranchTouched += ActivatePhysics;

    }

    private void OnDisable()
    {
        _stickman.BranchTouched -= ActivatePhysics;
    }
    
    private void ActivatePhysics()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        Punch();
    }

    private void Punch()
    {
        int index = Random.Range(0, _rigidbodiesForPunch.Count);
        
        _rigidbodiesForPunch[index].DOMove(transform.position + offset, _punchDuration);
    }
}

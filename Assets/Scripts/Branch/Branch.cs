using System;
using DG.Tweening;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public event Action FragmentTaken;
    public event Action<Transform> Cut; 
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Trap trap))
        {
            trap.TurnOffCollider();
            Cut?.Invoke(trap.CutPoint);
        }

        if (collider.TryGetComponent(out BranchFragment fragment))
        {
            FragmentTaken?.Invoke();
        }
    }
}
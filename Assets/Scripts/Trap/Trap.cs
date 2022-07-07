using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Trap : MonoBehaviour
{
    [SerializeField] private Transform _cutPoint;
    [SerializeField] private float _radius;
    
    private BoxCollider _collider;
    
    public Transform CutPoint => _cutPoint;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    public void TurnOffCollider()
    {
        _collider.enabled = false;
    }
}
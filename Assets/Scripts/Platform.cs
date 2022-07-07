using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;
    [Space]
    [SerializeField] private List<GameObject> _propsVariants;
    [SerializeField] private List<Transform> _trapsPoints;
    [SerializeField] private List<StickmansGroup> _stickmansGroups;
    [Space]
    [SerializeField] private GameObject _trap;

    public Transform StartPoint => _startPoint;
    public Transform EndPoint => _endPoint;

    private void Start()
    {
        ActiveProps();
        ActiveTrap();
        ChooseStickmansPositions();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Deactivator deactivator))
        {
            Deactivate();
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void ActiveProps()
    {
        int number = Random.Range(0, _propsVariants.Count);
    
        _propsVariants[number].SetActive(true);
    }

    private void ActiveTrap()
    {
        int index = Random.Range(0, _trapsPoints.Count-1);
        Vector3 position = _trapsPoints[index].transform.position;
        
        Instantiate(_trap, position, Quaternion.identity, transform);
    }

    private void ChooseStickmansPositions()
    {
        var index = Random.Range(0, _stickmansGroups.Count);
        
        _stickmansGroups[index].gameObject.SetActive(true);
    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class StickmansGroup : MonoBehaviour
{
    [SerializeField] private List<Pattern> _patterns;

    public event UnityAction InFiledOfView;

    private void Start()
    {
        ChoosePattern();
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Player player))
        {
            InFiledOfView?.Invoke();
        }
    }

    private void ChoosePattern()
    {
        var index = Random.Range(0, _patterns.Count);

        _patterns[index].gameObject.SetActive(true);
    }
}
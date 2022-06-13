using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    [SerializeField] private StickmansGroup _stickmansGroup;
    [SerializeField] private List<Stickman> _stickmans;

    private void OnEnable()
    {
        _stickmansGroup.InFiledOfView += ChangeState;
    }
    
    private void OnDisable()
    {
        _stickmansGroup.InFiledOfView -= ChangeState;
    }
    
    private void ChangeState()
    {
        int value = Random.Range(0,2);

        if (value == 1)
        {
            for (int i = 0; i < _stickmans.Count; i++)
            {
                _stickmans[i].ChangeAnimation();
            }
        }
    }
}
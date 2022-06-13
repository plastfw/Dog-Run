using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private Finish _finish;
    [SerializeField] private GameObject _pool;
    [Space]
    [Range(1,30)][SerializeField] private int _lenght;
    
    private Platform _lastSpawned;
    private Platform _currentPlatform;

    private void Start()
    {
        MakeRoad();
    }
    
    private void MakeRoad()
    {
        for (int i = 0; i < _lenght; i++)
        {
            if (i == 0)
            {
                _lastSpawned =  Instantiate(_platform,_pool.transform);
            }
            else
            {
                _currentPlatform = Instantiate(_platform,_pool.transform);
                _currentPlatform.transform.position = _lastSpawned.EndPoint.position - _currentPlatform.StartPoint.localPosition;
                _lastSpawned = _currentPlatform;
            }
        }
        CreateFinish();
    }
    
    private void CreateFinish()
    {
        Finish finish = Instantiate(_finish,_pool.transform);
        finish.transform.position = Vector3.zero;
        finish.transform.position = _lastSpawned.EndPoint.position - finish.StartPoint.position;
    }
}
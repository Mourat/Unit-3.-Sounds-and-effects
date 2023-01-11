using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private Vector3 _spawnPos;
    private float _startDelay;
    private float _repeatRate;

    private void Awake()
    {
        _spawnPos = new Vector3(25, 0, 0);
        _startDelay = 2;
        _repeatRate = 2;
    }

    private void Start()
    {
        InvokeRepeating("SpawnObstacle", _startDelay, _repeatRate);
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, _spawnPos, obstaclePrefab.transform.rotation);
    }
}
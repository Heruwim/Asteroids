using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private float _spawtRate = 2f;
    [SerializeField] private int _spawnAmount = 1;
    [SerializeField] private Asteroid _asteroidPrefab;
    [SerializeField] private float _spawnDistance = 15f;
    [SerializeField] private float _trajectoryVariance = 15f;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), _spawtRate, _spawtRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * _spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;
            
            float variance = Random.Range(-_trajectoryVariance, _trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            
            Asteroid asteroid = Instantiate(_asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }   
}

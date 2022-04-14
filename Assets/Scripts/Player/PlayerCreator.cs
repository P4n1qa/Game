using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCreator : MonoBehaviour
{
    [SerializeField]private GameObject _player;
    [SerializeField]private List<Transform> _listSpawnPoints;
    
    private Transform _spawnPoint;

    private void Awake()
    {
        SpawnHero();
    }

    private void RandomSpawn()
    {
        _spawnPoint = _listSpawnPoints[Random.Range(0, _listSpawnPoints.Count)];
    }
    private void SpawnHero()
    {
        RandomSpawn();
        Instantiate(_player, _spawnPoint.position,Quaternion.identity, transform);
    }
}

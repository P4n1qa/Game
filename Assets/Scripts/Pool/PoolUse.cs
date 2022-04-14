using UnityEngine;
using Random = UnityEngine.Random;

public class PoolUse : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemySpawnContainer enemySpawnContainer;

    private PoolMono<Enemy> _pool;

    private void Start()
    {
        this._pool = new PoolMono<Enemy>(this._enemy, this._poolCount, this.transform);
        this._pool.AutoExpand = this._autoExpand;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            this.CreateEnemy();
    }

    private void CreateEnemy()
    {
        Transform enemyPosition = enemySpawnContainer.EnemySpawns[Random.Range(0, enemySpawnContainer.EnemySpawns.Count)];
        var enemy = this._pool.GetFreeElement();
        enemy.transform.position = enemyPosition.position;
        enemy.Move();
    }
}

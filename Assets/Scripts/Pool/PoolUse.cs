using UnityEngine;
using Random = UnityEngine.Random;

public class PoolUse : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private EnemyLevel1 enemyLevel1;
    [SerializeField] private EnemyLevel2 enemyLevel2;
    [SerializeField] private EnemyLevel3 enemyLevel3;
    [SerializeField] private EnemySpawnPointsContainer enemySpawnPointsContainer;

    private PoolMono<EnemyLevel1> _poolEnemyLevel1;
    private PoolMono<EnemyLevel2> _poolEnemyLevel2;
    private PoolMono<EnemyLevel3> _poolEnemyLevel3;

    private void Start()
    {
        CreatePoolEnemyLevel1();
        CreatePoolEnemyLevel2();
        CreatePoolEnemyLevel3();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateEnemyLevel1();
            CreateEnemyLevel2();
            CreateEnemyLevel3();
        }
    }

    private void CreatePoolEnemyLevel1()
    {
        this._poolEnemyLevel1 = new PoolMono<EnemyLevel1>(this.enemyLevel1, this._poolCount, this.transform);
        this._poolEnemyLevel1.AutoExpand = this._autoExpand;
    }
    private void CreatePoolEnemyLevel2()
    {
        this._poolEnemyLevel2 = new PoolMono<EnemyLevel2>(this.enemyLevel2, this._poolCount, this.transform);
        this._poolEnemyLevel2.AutoExpand = this._autoExpand;
    }
    private void CreatePoolEnemyLevel3()
    {
        this._poolEnemyLevel3 = new PoolMono<EnemyLevel3>(this.enemyLevel3, this._poolCount, this.transform);
        this._poolEnemyLevel3.AutoExpand = this._autoExpand;
    }
    private void CreateEnemyLevel1()
    {
        Transform enemyPosition = enemySpawnPointsContainer.EnemySpawns[Random.Range(0, enemySpawnPointsContainer.EnemySpawns.Count)];
        var enemyLevel1 = this._poolEnemyLevel1.GetFreeElement();
        enemyLevel1.transform.position = enemyPosition.position;
        enemyLevel1.StartEnemy();
    }
    private void CreateEnemyLevel2()
    {
        Transform enemyPosition = enemySpawnPointsContainer.EnemySpawns[Random.Range(0, enemySpawnPointsContainer.EnemySpawns.Count)];
        var enemyLevel2 = this._poolEnemyLevel2.GetFreeElement();
        enemyLevel2.transform.position = enemyPosition.position;
        enemyLevel2.StartEnemy();
    }
    private void CreateEnemyLevel3()
    {
        Transform enemyPosition = enemySpawnPointsContainer.EnemySpawns[Random.Range(0, enemySpawnPointsContainer.EnemySpawns.Count)];
        var enemyLevel3 = this._poolEnemyLevel3.GetFreeElement();
        enemyLevel3.transform.position = enemyPosition.position;
        enemyLevel3.StartEnemy();
    }
}

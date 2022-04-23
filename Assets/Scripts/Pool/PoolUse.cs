using UnityEngine;
using Random = UnityEngine.Random;

public class PoolUse : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private int _poolCountWeapon;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private EnemyLevel0 enemyLevel0;
    [SerializeField] private EnemyLevel1 enemyLevel1;
    [SerializeField] private EnemyLevel2 enemyLevel2;
    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private EnemySpawnPointsContainer _enemySpawnPointsContainer;

    private PoolMono<EnemyLevel0> _poolEnemyLevel1;
    private PoolMono<EnemyLevel1> _poolEnemyLevel2;
    private PoolMono<EnemyLevel2> _poolEnemyLevel3;
    private PoolMono<EnemyWeapon> _poolEnemyWeapon;
    private PoolMono<PlayerWeapon> _poolPlayerWeapon;

    private void Awake()
    {
        CreatePoolEnemyLevel1();
        CreatePoolEnemyLevel2();
        CreatePoolEnemyLevel3();
        CreatePoolEnemyWeapon();
        CreatePoolPlayerWeapon();
    }

    private void Start()
    {
        CreateEnemyLevel1();
        CreateEnemyLevel2();
        CreateEnemyLevel3();
    }
    private void CreatePoolEnemyWeapon()
    {
        this._poolEnemyWeapon = new PoolMono<EnemyWeapon>(this._enemyWeapon, this._poolCountWeapon, this.transform);
        this._poolEnemyWeapon.AutoExpand = this._autoExpand;
    }
    public void CreateEnemyWeapon(Transform EnemyPosition , float ForceBullet)
    {
        var enemyWeapon = _poolEnemyWeapon.GetFreeElement();
        enemyWeapon.transform.position = EnemyPosition.position;
        enemyWeapon.GetComponent<Rigidbody2D>().AddForce(new Vector2(-ForceBullet, 0));
    }
    private void CreatePoolPlayerWeapon()
    {
        this._poolPlayerWeapon = new PoolMono<PlayerWeapon>(this._playerWeapon, this._poolCountWeapon, this.transform);
        this._poolPlayerWeapon.AutoExpand = this._autoExpand;
    }
    public void CreatePlayerWeapon(Transform PlayerPosition , float ForceBullet)
    {
        var playerWeapon = _poolPlayerWeapon.GetFreeElement();
        playerWeapon.transform.position = PlayerPosition.position;
        playerWeapon.GetComponent<Rigidbody2D>().AddForce(new Vector2(ForceBullet, 0));
    }

    private void CreatePoolEnemyLevel1()
    {
        this._poolEnemyLevel1 = new PoolMono<EnemyLevel0>(this.enemyLevel0, this._poolCount, this.transform);
        this._poolEnemyLevel1.AutoExpand = this._autoExpand;
    }
    private void CreatePoolEnemyLevel2()
    {
        this._poolEnemyLevel2 = new PoolMono<EnemyLevel1>(this.enemyLevel1, this._poolCount, this.transform);
        this._poolEnemyLevel2.AutoExpand = this._autoExpand;
    }
    private void CreatePoolEnemyLevel3()
    {
        this._poolEnemyLevel3 = new PoolMono<EnemyLevel2>(this.enemyLevel2, this._poolCount, this.transform);
        this._poolEnemyLevel3.AutoExpand = this._autoExpand;
    }
    private void CreateEnemyLevel1()
    {
        Transform enemyPosition = _enemySpawnPointsContainer.EnemySpawns[Random.Range(0, _enemySpawnPointsContainer.EnemySpawns.Count)];
        var enemyLevel1 = this._poolEnemyLevel1.GetFreeElement();
        enemyLevel1.transform.position = enemyPosition.position;
        enemyLevel1.StartEnemy();
    }
    private void CreateEnemyLevel2()
    {
        Transform enemyPosition = _enemySpawnPointsContainer.EnemySpawns[Random.Range(0, _enemySpawnPointsContainer.EnemySpawns.Count)];
        var enemyLevel2 = this._poolEnemyLevel2.GetFreeElement();
        enemyLevel2.transform.position = enemyPosition.position;
        enemyLevel2.StartEnemy();
    }
    private void CreateEnemyLevel3()
    {
        Transform enemyPosition = _enemySpawnPointsContainer.EnemySpawns[Random.Range(0, _enemySpawnPointsContainer.EnemySpawns.Count)];
        var enemyLevel3 = this._poolEnemyLevel3.GetFreeElement();
        enemyLevel3.transform.position = enemyPosition.position;
        enemyLevel3.StartEnemy();
    }
}

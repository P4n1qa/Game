using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemySettings EnemySettings;
    [SerializeField] private int _levelEnemy;
    
    private NavMeshAgent _navMeshAgent;
    private PoolUse _poolUse;
    private SliderHealhEnemy _sliderHealhEnemy;
    private float _forceBullet;
    private float _duractionShot;
    private int _health;


    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        StartCoroutine(CR_StartShot());
        GetInfo();
    }

    private void GetInfo()
    {
        _health = EnemySettings.ListEnemySettings[_levelEnemy].Health;
        _forceBullet = EnemySettings.ListEnemySettings[_levelEnemy].ForceBullet;
        _duractionShot = EnemySettings.ListEnemySettings[_levelEnemy].DuractionShot;
    }
    private void Start()
    {
        _poolUse = FindObjectOfType<PoolUse>().GetComponent<PoolUse>();
        _sliderHealhEnemy = GetComponentInChildren<SliderHealhEnemy>();
    }
    public void GetDamage()
    {
        
        if (_health > 1)
        {
            _health -= 1;
            _sliderHealhEnemy.RestoreSlider(_health);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void StartEnemy()
    {
        StartCoroutine(CR_StartEnemyWalk());
    }

    public void Shot()
    {
        _poolUse.CreateEnemyWeapon(this.transform , _forceBullet);
    }

    private IEnumerator CR_StartShot()
    {
        yield return new WaitForSeconds(_duractionShot);
        Shot();
        yield return new WaitForSeconds(_duractionShot);
        StartCoroutine(CR_StartShot());
    }
    private IEnumerator CR_StartEnemyWalk()
    {
        Vector3 rnd = RandomNavMeshPoint.GetRandomPointOnNavMesh();
        rnd.z = 0f;
        while (_navMeshAgent.gameObject.transform.position != new Vector3(rnd.x,rnd.y,-1.083333f))
        {
            _navMeshAgent.SetDestination(rnd);
            yield return null;
        }
        RandomAction();
    }

    private void RandomAction()
    {
        int i = Random.Range(0, 5);
        if (i == 0)
        {
            StartCoroutine(CR_Wait());
        }
        else
        {
            StartEnemy();
        }
    }
    private IEnumerator CR_Wait()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(CR_StartEnemyWalk());
    }

    private void OnDisable()
    {
        StopCoroutine(CR_StartShot());
        StopCoroutine(CR_StartEnemyWalk());
    }
}

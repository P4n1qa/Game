using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _forceBullet;
    [SerializeField] private float _duractionShot;
    
    private NavMeshAgent _navMeshAgent;

    private void OnEnable()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        StartCoroutine(CR_StartShot());
    }

    public void StartEnemy()
    {
        StartCoroutine(CR_StartEnemyWalk());
    }

    public void Shot()
    {
        GameObject newBullet = Instantiate(_bullet, transform.position, quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-_forceBullet, 0));
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

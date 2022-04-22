using IInterface;
using UnityEngine;

public class EnemyLevel1 : Enemy , IEnemy
{
    [SerializeField] private GameObject _bullet;
    public void Move()
    {
        
    }

    public void Shot()
    {
        throw new System.NotImplementedException();
    }

    public void Death()
    {
        throw new System.NotImplementedException();
    }
}

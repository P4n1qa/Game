using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySettingsSmall
{
   public int Health;
   public float ForceBullet;
   public float DuractionShot;
}

[CreateAssetMenu(fileName = "EnemySettings")]
public class EnemySettings : ScriptableObject
{
   public List<EnemySettingsSmall> ListEnemySettings;
}

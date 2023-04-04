using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfig", menuName = "GameConfigs/New EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    public int Health = 4;
    public int Damage = 2;
    public float AttackSpeed = 2;
    public float MoveSpeed = 2;
    public float TimeOfImmobility = 2;
    public float ShootingRange = 10;
    public float ShootingPeriod = 2;


}

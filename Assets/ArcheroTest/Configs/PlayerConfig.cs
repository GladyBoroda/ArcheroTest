using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "GameConfigs/New PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    public float MoveSpeed;

    [Range(0f, 15f)]
    public float RotateLerpSpeed;

    public float AttackSpeed;

}

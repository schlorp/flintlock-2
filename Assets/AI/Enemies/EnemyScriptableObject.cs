using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    test,
}

[CreateAssetMenu(fileName = "New Enemy", menuName = "EnemySO")]
public class EnemyScriptableObject : ScriptableObject
{
    public new string name;
    [Header("stats")]
    public float health;
    public float damage;
    public float attackspeed;
    public float speed;


    public EnemyType enemyType;
}

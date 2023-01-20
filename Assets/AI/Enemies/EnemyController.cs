using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyScriptableObject data;

    private float health;
    private float damage;
    private float attackspeed;
    private float speed;

    private EnemyType enemyType;

    public void Awake()
    {
        //setting data
        health = data.health;
        damage = data.damage;
        attackspeed = data.attackspeed;
        speed = data.speed;
        enemyType = data.enemyType;
    }
}

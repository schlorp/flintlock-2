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
    private Animator animator;


    public void Awake()
    {
        //setting self up
        health = data.health;
        damage = data.damage;
        attackspeed = data.attackspeed;
        speed = data.speed;
        enemyType = data.enemyType;

        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            animator.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            animator.SetBool("Jump", false);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthComponent : GeneralHealthComponent
{
    [SerializeField] private EnemyScriptableObject enemydata;

    private void Awake()
    {
        SetCurrentHealth(enemydata.health);
    }
    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
    }
    protected override void Die()
    {
        base.Die();
        Destroy(gameObject);
    }
}

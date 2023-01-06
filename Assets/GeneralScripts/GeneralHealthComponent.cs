using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralHealthComponent : MonoBehaviour
{
    private float currenthealth;
    public virtual void TakeDamage(float _damage)
    {
        currenthealth -= _damage;

        if(currenthealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
    }
    public void SetCurrentHealth(float _newhealth)
    {
        currenthealth = _newhealth;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "EnemySO")]
public class EnemyScriptableObject : ScriptableObject
{
    public new string name;

    public float health;
}

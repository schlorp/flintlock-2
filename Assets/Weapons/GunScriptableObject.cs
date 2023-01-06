using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FireMode
{
    Semi,
    Auto
}
public enum AmmoType
{
    Bullet,
    Rocket,
    Palet
}
[CreateAssetMenu(fileName = "New Gun", menuName = "GunSO")]
public class GunScriptableObject : ScriptableObject
{
    public new string name;

    public float damage;
    public float firerate;

    public FireMode firemode;
    public AmmoType ammotype;

    public float magammo;
    public float pouchammo;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Gun : MonoBehaviour
{
    [SerializeField] private GunScriptableObject gundata;
    [SerializeField] private LayerMask enemylayer;
    [SerializeField] private Transform firepoint;
    
    private GeneralInputActions inputactions;
    private InputAction fire;

    private bool isfired;

    private Movement playermovement;

    private Vector2 raycastdirection;


    [Header("GunData")]
    private float damage;
    private float firerate;
    private FireMode firemode;
    private AmmoType ammotype;
    private float magammo;
    private float pouchammo;

    private void Awake()
    {
        //setting up own variables
        playermovement = gameObject.GetComponentInParent<Movement>();
        inputactions = new GeneralInputActions();
        fire = inputactions.Player.Fire;

        damage = gundata.damage;
        firerate = gundata.firerate;
        firemode = gundata.firemode;
        ammotype = gundata.ammotype;
        magammo = gundata.magammo;
        pouchammo = gundata.pouchammo;
    }
    private void OnEnable()
    {
        fire.Enable();
    }
    private void OnDisable()
    {
        fire.Disable();
    }

    private void Update()
    {
        ChangeFirePointDirection();
        switch (firemode)
        {
            case FireMode.Semi:
                if (fire.triggered && !isfired)
                {
                    CheckAmmo();
                }
                break;
            case FireMode.Auto:
                if (fire.IsPressed() && !isfired)
                {
                    CheckAmmo();
                }
                break;
        }
    }
    private void CheckAmmo()
    {
        switch (ammotype)
        {
            case AmmoType.Bullet:
                StartCoroutine(Shoot());
                break;
            case AmmoType.Rocket:
                StartCoroutine(ShootRocket());
                break;
            case AmmoType.Palet:
                StartCoroutine(ShootPalet());
                break;
        }
    }
    private IEnumerator Shoot()
    {
        isfired = true;
        //shoot out a raycast and check if it hits an enemy
        RaycastHit2D hit = Physics2D.Raycast(firepoint.position, raycastdirection,Mathf.Infinity, enemylayer);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.transform.name);
            //do damage to the enemy
            hit.collider.GetComponent<EnemyHealthComponent>().TakeDamage(damage);
        }
        //wait before fire again
        yield return new WaitForSeconds(firerate);
        //after wait
        isfired = false;
    }
    private IEnumerator ShootRocket()
    {
        isfired = true;
        //shooty stuff with rocket

        //wait before fire again
        yield return new WaitForSeconds(firerate);
        //after wait
        isfired = false;
    }
    private IEnumerator ShootPalet()
    {
        isfired = true;
        //shooty stuff with palets

        //wait before fire again
        yield return new WaitForSeconds(firerate);
        //after wait
        isfired = false;
    }
    private void ChangeFirePointDirection()
    {
        bool facingright = playermovement.GetFacingRight();

        if (!facingright)
        {
            raycastdirection = -Vector2.right;
        }
        else
        {
            raycastdirection = Vector2.right;
        }
    }
}

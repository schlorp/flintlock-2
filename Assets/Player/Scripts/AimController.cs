using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Aimcontroller : MonoBehaviour
{
    [SerializeField] private GeneralInputActions inputactions;
    //[SerializeField] private Transform guntransform;
    private InputAction look;

    private void Awake()
    {
        inputactions = new GeneralInputActions();
        look = inputactions.Player.Look;
    }
    private void OnEnable()
    {
        look.Enable();
    }
    private void OnDisable()
    {
        look.Disable();
    }
    private void Update()
    {
        Vector3 mouseposition = Mouse.current.position.ReadValue();
        mouseposition.z = transform.position.z;

        Vector3 target = Camera.main.ScreenToWorldPoint(mouseposition);

        Vector3 difference =  target - transform.position;
        float rotationz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationz);
        //guntransform.rotation = Quaternion.Euler(guntransform.rotation.y, guntransform.rotation.x, transform.rotation.z);

        /*
        Vector3 rotation = mouseposition - transform.position;
        float rotationz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotationz);
        */
    }
}

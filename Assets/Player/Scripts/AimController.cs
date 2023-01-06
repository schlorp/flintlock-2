using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Aimcontroller : MonoBehaviour
{
    [SerializeField] private GeneralInputActions inputactions;
    private InputAction look;

    [SerializeField] private Transform guntransform;

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
        //get mouse pos
        Vector3 mouseposition = Mouse.current.position.ReadValue();
        mouseposition.z = transform.position.z;
        //get mouse pos in world
        Vector3 target = Camera.main.ScreenToWorldPoint(mouseposition);
        //rotate the gun
        Vector3 difference =  target - guntransform.transform.position;
        float rotationz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        guntransform.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationz);
    }
}

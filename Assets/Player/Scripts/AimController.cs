using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimController : MonoBehaviour
{
    [SerializeField] private GunScriptableObject gundata;

    private GeneralInputActions inputactions;
    private InputAction zoom;

    private Camera cam;

    private void Awake()
    {
        inputactions = new GeneralInputActions();
        zoom = inputactions.Player.Zoom;
        cam = GetComponentInChildren<Camera>();
    }
    private void OnEnable()
    {
        zoom.Enable();
    }
    private void OnDisable()
    {
        zoom.Disable();
    }
    private void Update()
    {
        if (zoom.IsPressed())
        {
            //zoom into the gun and let it aim
            GunFollowMouse();
        }
    }

    private void GunFollowMouse()
    {
        //gun follows the mouse around the player so you can aim and shoot
    }
}

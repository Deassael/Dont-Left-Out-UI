using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonControl : MonoBehaviour
{
    //References
    private Camera _camera;

    //Input System
    private PlayerControls _playerCanonControls;
    
    void Awake()
    {
        _camera = FindObjectOfType<Camera>();
        _playerCanonControls = new PlayerControls();
    }

    void Update()
    {
        transform.LookAt(ObtainMouseWorldPosition());
    }

    private Vector3 ObtainMouseWorldPosition()
    {
        Vector3 mousePosition = _playerCanonControls.Player.Aiming.ReadValue<Vector2>();
        Ray ray = _camera.ScreenPointToRay(mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 46, Color.red);
        Vector3 lookAtPoint = ray.GetPoint(46);
        lookAtPoint.y = transform.position.y;
        return lookAtPoint;
    }

    public void EnableCanonControls()
    {
        _playerCanonControls.Player.Enable();
    }
    
    public void DisableCanonControls()
    {
        _playerCanonControls.Player.Disable();
    }

    private void OnDisable()
    {
        _playerCanonControls.Player.Disable();
    }
}

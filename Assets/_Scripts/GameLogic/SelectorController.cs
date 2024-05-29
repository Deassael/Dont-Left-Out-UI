using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorController : MonoBehaviour
{
    private Camera _camera;
   
    void Awake()
    {
        _camera = FindObjectOfType<Camera>();
    }
    void Update()
    {
        if (GameManager.Instance.IsAlreadyInMainMenu&&!MenuManager.Instance.IsMenuOpen)
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = _camera.ScreenPointToRay(mousePosition);
            Vector3 mousePointingPosition = ray.GetPoint(46);
            mousePointingPosition.y = 1;
            transform.position = mousePointingPosition;
        }
    }
}

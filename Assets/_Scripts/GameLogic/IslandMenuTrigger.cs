using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandMenuTrigger : MonoBehaviour
{
    
    [SerializeField] private string menuName;
    [SerializeField] private GameObject island;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MenuManager.Instance.OpenMenuName(menuName);
        }
        else if (other.CompareTag("Selector"))
        {
            island.transform.localScale = Vector3.one*530;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MenuManager.Instance.CloseAllMenus();
        }
        else if (other.CompareTag("Selector"))
        {
            island.transform.localScale = Vector3.one*420;
        }
    }
}

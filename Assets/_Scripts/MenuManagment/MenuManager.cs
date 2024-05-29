using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] MenuVisibility[] menus;

    public bool IsMenuOpen { private set; get; }
    
    public static MenuManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenuName(string menuName)
    {
        IsMenuOpen = true;
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                menus[i].SetMenuVisible();
            }
            else if (menus[i].IsOpen)
            {
                CloseMenu(menus[i]);
            }
        }
    }
    
    public void CloseMenuName(string menuName)
    {
        IsMenuOpen = false;
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].menuName == menuName)
            {
                menus[i].SetMenuNoVisible();
            }
        }
    }
    
    public void CloseAllMenus()
    {
        IsMenuOpen = false;
        foreach (var menu in menus)
        {
            menu.SetMenuNoVisible();
        }
    }
    
    public void OpenMenu(MenuVisibility menu)
    {
        IsMenuOpen = true;
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].IsOpen)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.SetMenuVisible();
    }
    
    void CloseMenu(MenuVisibility menu)
    {
        IsMenuOpen = false;
        menu.SetMenuNoVisible();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{
    private Camera _camera;
    private CameraController _cameraController;
    public bool IsAlreadyInMainMenu { private set; get; }

    public static GameManager Instance;
    
    [SerializeField] private GameObject playerBoatMenu;

    private void Awake()
    {
        _camera = FindObjectOfType<Camera>();
        _cameraController = _camera.GetComponent<CameraController>();
        Instance = this;
    }

    private void Start()
    {
        IsAlreadyInMainMenu = false;
    }

    public override void OnJoinedLobby()
    {
        if (!IsAlreadyInMainMenu)
        {
            StartGameMenu();
            IsAlreadyInMainMenu = true;
        }
    }

    private void StartGameMenu()
    {
        {
            _cameraController.SetCameraTopDownView();
            playerBoatMenu.GetComponentInChildren<CannonControl>().EnableCanonControls();
            playerBoatMenu.GetComponent<ShipController>().EnableMovementControls();
        }
    }

    public override void OnJoinedRoom()
    {
       _cameraController.MoveCameraToRoomScenario();
       playerBoatMenu.GetComponentInChildren<CannonControl>().DisableCanonControls();
       playerBoatMenu.GetComponent<ShipController>().DisableMovementControls();
    }

    public override void OnLeftRoom()
    {
        _cameraController.MoveCameraToMenuScenario();
        playerBoatMenu.GetComponentInChildren<CannonControl>().EnableCanonControls();
        playerBoatMenu.GetComponent<ShipController>().EnableMovementControls();
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatePlayer : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject myPlayerManagerPrefab;
    private void Start()
    {
        PhotonNetwork.Instantiate(this.myPlayerManagerPrefab.name,
            new Vector3(0, 10, 0), Quaternion.identity);
    }
}

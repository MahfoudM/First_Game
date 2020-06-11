using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Photon.Pun.MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private CinemachineFreeLook playerCamera = null;

    void Start()
    {
        var player = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
        playerCamera.Follow = player.transform;
        playerCamera.LookAt = player.transform;
    }

}

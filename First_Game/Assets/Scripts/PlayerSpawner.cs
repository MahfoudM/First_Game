using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private CinemachineFreeLook playerCamera = null;

    public Vector3 spawnPos;


    void Start()
    {
        var player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity);
        playerCamera.Follow = player.transform;
        playerCamera.LookAt = player.transform;
    }
}

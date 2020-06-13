using Cinemachine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private CinemachineFreeLook playerCamera = null;


    void Start()
    {
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);

            var player = PhotonNetwork.Instantiate(playerPrefab.name, GameSetup.GS.spawnPoints[spawnPicker].position, GameSetup.GS.spawnPoints[spawnPicker].rotation);
            playerCamera.Follow = player.transform;
            playerCamera.LookAt = player.transform;
    }

}

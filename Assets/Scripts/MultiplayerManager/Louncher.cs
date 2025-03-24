using UnityEngine;
using Photon.Pun;

public class Louncher : MonoBehaviourPunCallbacks
{
    public PhotonView PlayerPrefab;
    public Transform SpawnPoint;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnPoint.position, SpawnPoint.rotation);
    }
}

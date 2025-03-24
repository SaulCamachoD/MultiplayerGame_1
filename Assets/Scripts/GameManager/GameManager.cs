using System;
using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{   
    [Header("Instancias de Scripts")]
    public WindowController windowController;
    
    [Header("Indicadores")]
    public TMP_Text indicatorText;
    public TMP_Text namePlayerText;
    public Transform contentPlayers;

    [Header("Prefabs")] 
    public GameObject nickNamePlayer;
    
    [Header("Menu Buttons")]
    public GameObject btnStart;
    public GameObject btnConnet;

    private int countPlayer = 0;
    private void Start()
    {
        btnConnet.SetActive(false);
    }

    public void ConnectToPhoton()
    {
        if(!PhotonNetwork.IsConnected)
            PhotonNetwork.ConnectUsingSettings();
    }
    
    public void CreatePlayer(string PlayerName)
    {  
        PhotonNetwork.NickName = PlayerName;
    }
    
    //Conectamos a internet
    public override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("Connected");
        indicatorText.text = "Connected";
    }
    //Conectamos al servidos de Photon
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        indicatorText.text = "Welcome " + PhotonNetwork.NickName;
        btnStart.GetComponent<Button>().interactable = false;
        btnConnet.SetActive(true);
        
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
    }

    public void CreateRoom()
    {
        string user = PhotonNetwork.NickName;
        string room = "Main Room";
        
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 4;
        roomOptions.PublishUserId = true;
        
        PhotonNetwork.JoinOrCreateRoom(room, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        windowController.EnableWindows(1);
        StartCoroutine(UpdateTextRoom());
        Debug.Log("Joined Room " + PhotonNetwork.CurrentRoom.Name + " Welcome " + PhotonNetwork.NickName);
    }

    IEnumerator UpdateTextRoom()
    {
        while (true)
        {   
            namePlayerText.text = $" Room: {PhotonNetwork.CurrentRoom.Name} - Players: {PhotonNetwork.CurrentRoom.PlayerCount}";
            yield return new WaitForSeconds(0.2f);

            if (PhotonNetwork.CurrentRoom.Players.Count != countPlayer)
            {
                countPlayer = PhotonNetwork.CurrentRoom.Players.Count;
                
                foreach (Transform child in contentPlayers)
                {
                    Destroy(child.gameObject);
                }
                
                foreach (var player in PhotonNetwork.CurrentRoom.Players.Values)
                {   
                    GameObject nickName = Instantiate(nickNamePlayer, contentPlayers);
                    nickName.GetComponent<TMP_Text>().text = player.NickName;
                }
            }
        }
    }
}

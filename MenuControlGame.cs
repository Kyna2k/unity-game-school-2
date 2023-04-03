using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControlGame : MonoBehaviour
{
    [SerializeField] private string VersionGame = "0.1";
    [SerializeField] private GameObject MenuGame;
    [SerializeField] private GameObject ConnectionControll;

    [SerializeField] private InputField Usernameinput;
    [SerializeField] private InputField CreateInputGame;
    [SerializeField] private InputField JoinGameInput;
    [SerializeField] private Button startButton;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionGame);
        Debug.Log("hello");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }
    public void SetUserName()
    {
        PhotonNetwork.playerName = Usernameinput.text;
    }
    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(CreateInputGame.text, new RoomOptions() { maxPlayers = 6 }, null);
    }
    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 6;
        PhotonNetwork.JoinOrCreateRoom(JoinGameInput.text, roomOptions, TypedLobby.Default);
    }
    public void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Man1");
    }
}

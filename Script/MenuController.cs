using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private InputField UserName;
    [SerializeField] private InputField Room;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersionName);
    }
    //Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }
    public void setUserName()
    {
        PhotonNetwork.playerName = UserName.text;
    }
    public void JoinGame()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(Room.text, roomOptions, TypedLobby.Default);
    }
    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("man1");
    }
    public void SinglePlay()
    {
        SceneManager.LoadScene("man1");
    }
}

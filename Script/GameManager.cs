using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerPrefab;
    public GameObject SceneCamera;
    public Text ping;
    public void SpawnPlayer() {
        float random = Random.Range(-1f, 1f);
        PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector2(this.transform.position.x * random, this.transform.position.y*random), Quaternion.identity, 0);
        //SceneCamera.SetActive(false);
    }
    private void Update()
    {
        ping.text = "Ping " + PhotonNetwork.GetPing();
    }
}

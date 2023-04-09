using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _player;
    // Start is called before the first frame update
    void Start()
    {

        GameObject main = PhotonNetwork.Instantiate(_player.name, new Vector2(-7.81f, -1.12f), Quaternion.identity, 0);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraNe>().NhanVat = main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

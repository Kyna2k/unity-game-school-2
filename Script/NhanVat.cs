using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NhanVat : DiChuyenNhanVat
{
    public Text diem, thongbao;
    public GameObject  Menu;
    public int vang;
    public PlayableDirector lenong;
    public bool die = false;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();

        if (LoginUser.loginReponModel.score != "")
        {
            vang = Int32.Parse(LoginUser.loginReponModel.score);
        }
        else
        {
            vang = 0;
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if(!die)
        {
            base.Update();

            if (diem != null)
            {
                diem.text = $"{vang} x";

            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Menu.SetActive(!Menu.active);

            }
            if (Menu.active)
            {
                Time.timeScale = 0;

            }
            else
            {
                Time.timeScale = 1;
            }
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       base.OnCollisionEnter2D(collision);
        if(collision.gameObject.tag == "vuc")
        {
            dead();
        }    

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "daibat")
        {
            PlaySounds("Sounds/jump");
            lenong.Play();
        }
        if(collision.gameObject.tag == "congquaman")
        {
            SceneManager.LoadScene("map2");
        }
        if(collision.gameObject.tag == "savegame")
        {
            StartCoroutine(saveScode());
        }
        if (collision.gameObject.tag == "savevitri")
        {
            StartCoroutine(saveVitri(collision.gameObject.transform));
        }
        if(collision.gameObject.tag == "dan")
        {
            soluongdan += 3;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "coin")
        {
            PlaySounds("Sounds/Coin");
        }
    }
    public IEnumerator cleanThongBao()
    {
        yield return new WaitForSeconds(3f);
        thongbao.text = "";
    }
    private IEnumerator saveScode()
    {
        UserModel userModel = new UserModel();
        userModel.username = LoginUser.loginReponModel.username;
        userModel.score = vang + "";
        string jsonStringRequest = JsonConvert.SerializeObject(userModel);

        var request = new UnityWebRequest("http://localhost:3000/luudiem", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            thongbao.text = $"Khong thanh cong {request.error}";
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            LoginReponModel loginReponModel = JsonConvert.DeserializeObject<LoginReponModel>(jsonString);
            if (loginReponModel.status == "0")
            {
                thongbao.text = $"{loginReponModel.notification}";
            }
            else
            {
                thongbao.text = $"{loginReponModel.notification}";
            }
        }
        StartCoroutine(cleanThongBao());
    }
    private IEnumerator saveVitri(Transform vector)
    {
        UserModel userModel = new UserModel();
        userModel.username = LoginUser.loginReponModel.username;
        userModel.positionY = vector.position.y.ToString();
        userModel.positionX = vector.position.x.ToString();
        userModel.positionZ = vector.position.z.ToString();
        string jsonStringRequest = JsonConvert.SerializeObject(userModel);
        var request = new UnityWebRequest("http://localhost:3000/luuvitrigame", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
            thongbao.text = $"Khong thanh cong {request.error}";
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            LoginReponModel loginReponModel = JsonConvert.DeserializeObject<LoginReponModel>(jsonString);
            if (loginReponModel.status == "0")
            {
                thongbao.text = $"{loginReponModel.notification}";
            }
            else
            {
                thongbao.text = $"{loginReponModel.notification}";
            }
        }
        StartCoroutine(cleanThongBao());
    }
    public void choilaivitrigannhat()
    {
           
            if (LoginUser.loginReponModel.positionX == "" && LoginUser.loginReponModel.positionY == "" && LoginUser.loginReponModel.positionZ == "")
            {
            gameObject.transform.position = new Vector3(-7.81f, -1.12f, 0);
            Time.timeScale = 1;
            }
            else
            {
            float x = float.Parse(LoginUser.loginReponModel.positionX);
            float y = float.Parse(LoginUser.loginReponModel.positionY);
            float z = float.Parse(LoginUser.loginReponModel.positionZ);
            gameObject.transform.position = new Vector3(x, y, z);
                Time.timeScale = 1;
            }

        
        
        die = false;
        Menu.SetActive(false);
        Menu.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void dead()
    {
        Menu.SetActive(true);
        Menu.transform.GetChild(0).gameObject.SetActive(false);
        die = true;
        Time.timeScale = 0;
    }
    public void PlaySounds(string name)
    {
        audioSource.PlayOneShot(Resources.Load<AudioClip>(name));
    }
}

using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoiMatkHau : MonoBehaviour
{
    public InputField oldpass, newpass;
    public Text thongbao;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0;
    }
    public void Dangky()
    {
        StartCoroutine(CheckLoginAPI());
    }
    public IEnumerator CheckLoginAPI()
    {
        var _oldpass = oldpass.text;
        var _newpass = newpass.text;
        UserModel userModel = new UserModel();
        userModel.username = LoginUser.loginReponModel.username;
        userModel.password = _oldpass;
        userModel.newpassword = _newpass;
        string jsonStringRequest = JsonConvert.SerializeObject(userModel);

        var request = new UnityWebRequest("http://localhost:3000/doimatkhau", "POST");
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

                SceneManager.LoadScene("Login");
            }
        }

    }
}

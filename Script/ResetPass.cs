using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetPass : MonoBehaviour
{
    public InputField editUser;
    public Text thongbao;
    public GameObject doimatkhau;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void sendOTP()
    {
        StartCoroutine(sendOTPApi());
    }
    public IEnumerator sendOTPApi()
    {
        var username = editUser.text;
        UserModel userModel = new UserModel(username,"");
        string jsonStringRequest = JsonConvert.SerializeObject(userModel);

        var request = new UnityWebRequest("http://localhost:3000/sendOTP", "POST");
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
                thongbao.text = "Thành công";

                doimatkhau.SetActive(true);
                gameObject.SetActive(false);
            }
        }

    }
}

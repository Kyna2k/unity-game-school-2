using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RestPass2 : MonoBehaviour
{
    public InputField editUser, newpassword, otp;
    public GameObject trangchu;
    public Text thongbao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetPass()
    {
        StartCoroutine(RestPassAPi());
    }
    public IEnumerator RestPassAPi()
    {
        var username = editUser.text;
        var _newpassword = newpassword.text;
        var _otp = otp.text;
        modelResetOTP modelResetOTP = new modelResetOTP(username, _newpassword, _otp);
        string jsonStringRequest = JsonConvert.SerializeObject(modelResetOTP);

        var request = new UnityWebRequest("http://localhost:3000/resetPass", "POST");
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
                trangchu.SetActive(true);
                gameObject.SetActive(false);
            }
        }

    }
}

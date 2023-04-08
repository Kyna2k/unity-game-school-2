using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginUser : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField editUser, editPass;
    public Text thongbao;
    public Selectable first;
    private EventSystem eventSystem;
    public Button btn_login;
    void Start()
    {
        eventSystem= EventSystem.current;
        first.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            btn_login.onClick.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Tab)) 
        { 
            Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            next?.Select();

        }
    }
    public void CheckLogin()
    {
        StartCoroutine(CheckLoginAPI());
    }
    public IEnumerator CheckLoginAPI()
    {
        var username = editUser.text;
        var password = editPass.text;
        UserModel userModel = new UserModel(username, password);
        string jsonStringRequest = JsonConvert.SerializeObject(userModel);

        var request = new UnityWebRequest("http://localhost:3000/dangnhap", "POST");
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
            if(loginReponModel.status == "0") {
                thongbao.text = $"{loginReponModel.notification}";
            }
            else
            {
                SceneManager.LoadScene("Man1");
            }
        }

    }
}

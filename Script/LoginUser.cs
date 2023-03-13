using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginUser : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField editUser, editPass;
    public Text thongbao;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckLogin()
    {
        var username = editUser.text;
        var password = editPass.text;
        if(username.Equals("admin") && password.Equals("admin"))
        {
            SceneManager.LoadScene("Man1");
        }
        else
        {
            thongbao.text = "Tài khoảng hoặc mật khẩu không chính xác";
        }    
    }
}

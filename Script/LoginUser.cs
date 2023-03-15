using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

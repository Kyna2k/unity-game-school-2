using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DangKy : MonoBehaviour
{
    public InputField editUser, editPass;
    public Text thongbao;
    public Selectable first;
    private EventSystem eventSystem;
    public Button btn_Dangky;
    public Button btn_back;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        first.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            btn_Dangky.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            next?.Select();

        }
    }
    public void Dangky()
    {
        var username = editUser.text;
        var password = editPass.text;
        btn_back.onClick.Invoke();
    }
}

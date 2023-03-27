using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NhanVat : DiChuyenNhanVat
{
    public Text diem;
    public GameObject Menu;
    public int vang;
    // Start is called before the first frame update
     void Start()
    {
        base.Start();
        //diem.text = "0 x";
        //vang = 0;   
    }

    // Update is called once per frame
    void Update()
    { 

        base.Update();
        //diem.text = $"{vang} x";
        //if (Input.GetKeyDown(KeyCode.Escape)) {
        //    Menu.SetActive(!Menu.active);
            
        //}
        //if (Menu.active)
        //{
        //    Time.timeScale = 0;

        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}
    }
    
}

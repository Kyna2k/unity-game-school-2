using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NhanVat : DiChuyenNhanVat
{
    public Text diem;
    public GameObject Menu;
    public int vang;
    public PlayableDirector lenong;
    // Start is called before the first frame update
     void Start()
    {
        base.Start();
        vang = 0;   
    }

    // Update is called once per frame
    void Update()
    { 

        base.Update();
        if(diem != null )
        {
            diem.text = $"{vang} x";

        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "daibat")
        {
            lenong.Play();
        }
        if(collision.gameObject.tag == "congquaman")
        {
            SceneManager.LoadScene("map2");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quai1 : QuaiVatDiChuyen
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }
    public void setStart(float left)
    {
        this.left = left;
    }
    public void setEnd(float right)
    {
        this.right = right;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("quai1"))
        {

            this.isRight = !this.isRight;
        }
        ContactPoint2D[] contacts = new ContactPoint2D[2];

        collision.GetContacts(contacts);
        if(collision.gameObject.tag == "nhanvat")
        {
            if (collision.contacts[0].normal.y < 0) {
                Destroy(gameObject);
            }
            else
            {
                 collision.gameObject.GetComponent<NhanVat>().dead();
            }
        }
    }
}

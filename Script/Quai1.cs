using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quai1 : QuaiVatDiChuyen
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
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
    }
}

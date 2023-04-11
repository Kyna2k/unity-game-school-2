using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin2 : COIN
{
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(collision.gameObject.tag == "nendat" || collision.gameObject.tag == "viengach")
        {
            Debug.Log("hello");
            rigidbody2D.AddForce(new Vector2(0, 20f));
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }
}

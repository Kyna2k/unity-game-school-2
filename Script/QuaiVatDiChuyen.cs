using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaiVatDiChuyen : MonoBehaviour
{
    public float left, right;
    public float speed;
    private Rigidbody2D Rigidbody2D;
    public bool isRight = false;
    public bool isDead;
    float scaleLocalY;
    float positionLocalY;
    // Start is called before the first frame update
    public void Start()
    {
        isDead = false;
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (isDead) return;
        float potitionX = transform.position.x;
        if (potitionX < left)
        {
            isRight = true;
        }
        if (potitionX > right)
        {
            isRight = false;
        }
        Vector3 vector3;
        if (isRight)
        {
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;
            vector3 = new Vector3(1, 0, 0);
        }
        else
        {
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;

            vector3 = new Vector3(-1, 0, 0);

        }
        transform.Translate(vector3 * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}


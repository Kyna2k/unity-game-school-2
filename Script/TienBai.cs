using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TienBai : MonoBehaviour
{
    private const float speed = 7f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] listGach = { gameObject.transform.GetChild(0).gameObject, gameObject.transform.GetChild(1).gameObject, gameObject.transform.GetChild(2).gameObject, gameObject.transform.GetChild(3).gameObject };
        listGach[0].GetComponent<Rigidbody2D>().velocity = new Vector2(-1, speed);
        listGach[1].GetComponent<Rigidbody2D>().velocity = new Vector2(1, speed);
        listGach[2].GetComponent<Rigidbody2D>().velocity = new Vector2(-1, -speed);
        listGach[3].GetComponent<Rigidbody2D>().velocity = new Vector2(1, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

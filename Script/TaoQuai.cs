using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaoQuai : MonoBehaviour
{
    private int count = 3;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count-- > 0)
        {
            float position = Random.Range(-5f, 6f);
            GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/quai1"),
                new Vector3(position, -3.5f, 0), Quaternion.identity);
            enemy.GetComponent<Quai1>().setStart(position - 5);
            enemy.GetComponent<Quai1>().setEnd(position + 6);
            //enemy.GetComponent<Quai1>().setPlayer(player);

        }
    }
}

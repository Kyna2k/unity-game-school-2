using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaoQuai : MonoBehaviour
{
    
    public GameObject player;
    private int soluong = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(taoquai());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator taoquai()
    {
        while(true)
        {
            yield return new WaitForSeconds(3f);
            soluong++;
            float position = Random.Range(-5f, 6f);
            GameObject enemy = (GameObject)Instantiate(Resources.Load("Prefabs/quai1"),
                new Vector3(position, -3.5f, 0), Quaternion.identity);
            enemy.GetComponent<Quai1>().setStart(position - 5);
            enemy.GetComponent<Quai1>().setEnd(position + 6);          
            if(soluong == 20)
            {
                break;
            }
        }
       
    }
}

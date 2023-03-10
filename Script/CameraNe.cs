using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNe : MonoBehaviour
{
   
    // Start is called before the first frame update
    public float left, right;
    public GameObject NhanVat;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var CameraX = transform.position.x;
        var CameraY = transform.position.y;
        if (NhanVat.transform.position.x >= left && NhanVat.transform.position.x <= right)
        {
            transform.position = new Vector3(NhanVat.transform.position.x, transform.position.y,
            transform.position.z);
        }
        else
        {
            if (CameraX < left) CameraX = left;
            if (CameraX < right) CameraX = right;
        }
       
    }
}

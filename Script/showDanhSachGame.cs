using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class showDanhSachGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetList());

    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale= 0f;
    }

    public IEnumerator GetList()
    {


        var request = new UnityWebRequest("http://localhost:3000/danhsachdiem", "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var jsonString = request.downloadHandler.text.ToString();
            List<LoginReponModel> loginReponModel = JsonConvert.DeserializeObject<List<LoginReponModel>>(jsonString);
            if(loginReponModel.Count != 0)
            {
                GameObject button = transform.GetChild(0).gameObject;
                GameObject g;
                for(int i = 0; i < loginReponModel.Count; i++)
                {
                    g = Instantiate(button,transform);
                    g.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Tên: " +loginReponModel[i].username;
                    g.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Score: "+loginReponModel[i].score;
                }
                Destroy(button);
            }    
        }

    }
}

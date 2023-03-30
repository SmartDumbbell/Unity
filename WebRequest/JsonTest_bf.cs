using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;

public class JsonTest_bf : MonoBehaviour
{
    public Text id;
    public Text pswd;

    public bool SignUpNextFlag;



    //싱글톤 해야함.

    void Start()
    {
        SignUpNextFlag = false;
    }


    void Update()
    {
        
    }

    public void sendButton()
    {
        //Debug.Log("아이디 : " + id.text + " 비밀번호 : " + pswd.text);


        try
        {
            //StartCoroutine(SendJsonData());
        }
        catch (Exception e)
        {
            print(e);
        }

    }
    public IEnumerator SendJsonData(string url, string json)
    {
        /*MyData data = new MyData();//클래스 객체 생성

        

        //객체 타입에 맞게 저장
        data.id = id.text.ToString();
        data.password = pswd.text.ToString();
        

        //중요
        string url = "http://localhost:8080/postMethod";//상황에 맞는 api 호출 -> 매핑된 url을 호출
        string json = JsonUtility.ToJson(data);//유니티에서 일반적인 클래스를 json으로 바꿔준다.*/

        print(json);

        UnityWebRequest request = UnityWebRequest.Post(url, json);

        request.SetRequestHeader("Content-Type", "application/json");

        //*******중요******
        byte[] jsonToSend = new UTF8Encoding().GetBytes(json);//바이트 배열 생성 후 json을 다시 인코딩
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);

        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
        }
    }

}


[System.Serializable]
public class MyData
{
    public string id;
    public string password;
}

[System.Serializable]
public class UserInfo
{
    public string name;
    public string id;
    public string password;
    public string weight;
    public string height;
    public string birth;
    public string gender;
    public string forgetText;
}

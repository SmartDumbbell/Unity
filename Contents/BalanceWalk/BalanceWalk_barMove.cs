using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 텍스트 매쉬 사용을 위한 네임스페이스
using TMPro;
using System.Xml.Linq;

public class BalanceWalk_barMove : MonoBehaviour
{
    public Slider slider_barRotate;
    public GameObject player;

    public float lerpSpeed_bar;
    public float playerSpeed;

    public GameObject settingScript;

    void Awake()
    {
        lerpSpeed_bar = 1f;
        playerSpeed = 2.5f;
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    // 플레이어의 속도를 조절할 수 있도록함.
    void Update()
    {
        if(Time.timeScale == 1)
        {
            player.transform.position = player.transform.position + new Vector3(0, 0, -playerSpeed * Time.deltaTime);
        }
    }

    // 슬라이더 바의 움직임에 따라서 GameObject bar를 회전시키는 함수
    public void rotate_bar(float value)
    {
        float targetRotation_bar = Mathf.Lerp(80, 100, slider_barRotate.value);
        Quaternion targetQuaternion_bar = Quaternion.Euler(0f, 0f, targetRotation_bar);
        transform.rotation = Quaternion.Lerp(transform .rotation, targetQuaternion_bar, lerpSpeed_bar);
    }

}

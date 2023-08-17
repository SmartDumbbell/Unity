using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


// 장애물 충돌 시 UGUI와 연결시킨 과일의 개수를 감소시키는 내용.
// 코루틴을 이용해 무적 시간 1초를 부여함.
// 또한 바구니의 색상을 반전시켜 무적 시간임을 알림.

public class BalanceWalk_burket : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;

    public Camera mainCamera;
    public GameObject burket_L;
    public GameObject burket_R;
    bool isUnBeatTime;

    Material burket_L_material;
    Material burket_R_material;

    // Setting
    public GameObject endPanel;

    public TextMeshProUGUI finalScore;

    void Awake()
    {
        isUnBeatTime = false;
        score = 0000;
        scoreText.text = "0000";
        burket_L_material = burket_L.GetComponent<MeshRenderer>().material;
        burket_R_material = burket_R.GetComponent<MeshRenderer>().material;

        StartCoroutine(AddPoint());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && !isUnBeatTime)
        {
            StartCoroutine(UnBeatTime());
        }

        // 여기 수정 .name X
        if(other.name == "EndPoint_Plane")
        {
            StartCoroutine(SlowDownTime());
        }
    }

    // 2초의 무적 시간을 부여함.
    IEnumerator UnBeatTime()
    {
        isUnBeatTime = true;
        score -= 200;
        scoreText.text = score.ToString();
        Color red = new Color(1, 0.5f, 0.5f);
        float BlinkTime = 0f;

        // 장애물 피격 시 화면 흔들림을 만듬------------------------------------------------------
        mainCamera.transform.position = mainCamera.transform.position + new Vector3(0.1f, 0, 0);
        yield return new WaitForSeconds(0.01f);
        mainCamera.transform.position = mainCamera.transform.position + new Vector3(-0.1f, 0, 0);
        yield return new WaitForSeconds(0.01f);
        mainCamera.transform.position = mainCamera.transform.position + new Vector3(-0.1f, 0, 0);
        yield return new WaitForSeconds(0.01f);
        mainCamera.transform.position = mainCamera.transform.position + new Vector3(0.1f, 0, 0);

        // 장애물 피격 시 양동이가 깜빡거리는 효과를 만듬-----------------------------------------
        while (BlinkTime < 2f)
        {
            burket_L_material.color = red;
            burket_R_material.color = red;

            yield return new WaitForSeconds(0.1f);
            burket_L_material.color = new Color(1, 1, 1);
            burket_R_material.color = new Color(1, 1, 1);
            yield return new WaitForSeconds(0.1f);

            BlinkTime += 0.2f;
        }
        isUnBeatTime = false;
    }

    // 게임 종료 -> 천천히 종료
    IEnumerator SlowDownTime()
    {
        Time.timeScale = Time.timeScale - 0.1f;
        yield return new WaitForSeconds(0.3f);
        Time.timeScale = Time.timeScale - 0.4f;
        yield return new WaitForSeconds(0.3f);

        finalScore.text = $"점수: {score:D4} 점";
        SaveScore();
        endPanel.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSeconds(0.3f);
    }

    IEnumerator AddPoint()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            score += 50;
            scoreText.text = score.ToString();
        }
    }
    private void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", score);
        PlayerPrefs.Save();
    }
}

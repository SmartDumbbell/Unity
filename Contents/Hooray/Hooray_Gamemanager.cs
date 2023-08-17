using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hooray_Gamemanager : MonoBehaviour
{
    private Coroutine objectSpawnCoroutine; //오브젝트 스폰 코루틴
    public Hooray_ObjectCreate objectCreate;
    public Hooray_PlayerRotate playerRotate;
    public TextMeshProUGUI score;
    public GameObject backgroudPanel;

    public GameObject emptycreate; // 오브젝트 생성 제어
    public TextMeshProUGUI text_Timer;
    private float time_start;
    private float time_current;
    public float time_Max;
    public bool isEnded;

    private int currentScore;
    private int savedScore;
    public TextMeshProUGUI finalScore;

    public TextMeshProUGUI countdownText;
    private float timer;
    private bool flag;

    private void Start()
    {
        flag = false;
        timer = 3f;
        Debug.Log("초기화됨");
        backgroudPanel.SetActive(false);
        time_Max = 60f; // 시간 최대치 설정
        Time.timeScale = 0;
        StartCoroutine(Count());
    }

    void Update()
    {
        if (isEnded)
            EndGame();

        Check_Timer();
    }

    public void StartGame()
    {
        if (Time.timeScale == 1 && flag)
        {
            Reset_Timer();
            objectSpawnCoroutine = StartCoroutine(objectCreate.spawnObject());
        }
    }

    private void Check_Timer()
    {
        if (Time.timeScale == 1 && flag)
        {
            time_current = Time.time - time_start;
            if (time_current < time_Max)
            {
                text_Timer.text = $"{time_current:N2}";
            }
            else if (!isEnded)
            {
                End_Timer();
            }
        }
    }

    private void End_Timer()
    {
        Debug.Log("End");
        time_current = time_Max;
        text_Timer.text = $"{time_current:N2}";
        isEnded = true;
    }

    private void Reset_Timer()
    {
        time_start = Time.time;
        time_current = 0;
        text_Timer.text = $"{time_current:N2}";
    }

    private void EndGame()
    {
        currentScore = int.Parse(score.text);

        finalScore.text = $"점수 : {currentScore:D4} 점";
        SaveScore();

        backgroudPanel.SetActive(true);
        Debug.Log("엔드게임");
        isEnded = false;
        Time.timeScale = 0;
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.Save();
    }

    private IEnumerator Count()
    {
        float currentTime = timer;
        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString("0");
            yield return new WaitForSeconds(1.0f);
            countdownText.gameObject.SetActive(true);
            currentTime--;
        }
        countdownText.text = "Start!";
        yield return new WaitForSeconds(1.0f);
        countdownText.gameObject.SetActive(false);

        flag = true;
        StartGame();
    }
}

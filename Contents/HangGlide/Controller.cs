using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using SerialData;
using updataData;

public class Controller : MonoBehaviour
{
    public Animator isPlaying;
    public GameObject runner;
    public Slider slider;
    public GameObject endPanel;
    public TextMeshProUGUI counter;

    [SerializeField]
    private int score;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countdownText;
    private float timer;
    private bool flag;
    private Rigidbody rigid;

    public GameObject Serial;

    public TextMeshProUGUI finalScore;

    void Start()
    {
        rigid = runner.GetComponent<Rigidbody>();        
        flag = false;
        timer = 3f;
        Time.timeScale = 0;
        score = 0000;

        StartCoroutine(Count());

        Serial = GameObject.Find("Serial");
    }

    private void FixedUpdate()
    {

        if (Time.timeScale == 1)
        {
            counter.gameObject.SetActive(true);
            runner.transform.Translate(Vector3.forward * 0.26f);

            // 위로 올라감
            if (flag)
            {
                counter.gameObject.SetActive(false);
                if (contentData.y >= 40)
                {
                    isPlaying.SetBool("isUp", true);
                    isPlaying.SetBool("isDown", false);
                    runner.transform.Translate(Vector3.up * 0.08f);
                }
                if (contentData.y <= 15)
                {
                    isPlaying.SetBool("isDown", true);
                    isPlaying.SetBool("isUp", false);
                    runner.transform.Translate(Vector3.down * 0.08f);
                }
            }
        }
    }

    private IEnumerator Count()
    {
        float currentTime = timer;

        StartCoroutine(Serial.GetComponent<Serial>().SetGyroMode());

        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString("0");
            yield return new WaitForSeconds(1.0f);
            currentTime--;
        }
        countdownText.text = "Start!";
        yield return new WaitForSeconds(1.0f);
        countdownText.gameObject.SetActive(false);

        flag = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            scoreText.text = score.ToString("0000");
            score += 100;
        }
        if (col.gameObject.CompareTag("Final"))
        {
            rigid.useGravity = true;
            rigid.isKinematic = false;
            flag = false;
            isPlaying.SetBool("isLanding", true);
            Invoke("FinishGame", 2f);
        }
        if (col.gameObject.CompareTag("GGWP"))
        {
            Debug.Log("HIT");
            FinishGame();
        }
    }

        private void FinishGame()
    {
        endPanel.SetActive(true);
        Time.timeScale = 0;

        finalScore.text = $"점수: {score:D4} 점";
        SaveScore();
    }

    private void SaveScore()
    {
        PlayerPrefs.SetInt("CurrentScore", score);
        PlayerPrefs.Save();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BalanceWalk_makeObstacle : MonoBehaviour
{
    public GameObject Player;
    public GameObject Obstacle;

    public float delayTime;
    public float curTime;
    public int countObstacle;

    void Start()
    {
        delayTime = 3.0f;
        curTime = 0;
        countObstacle = 0;
    }

    void Update()
    {
        curTime += Time.deltaTime;

        // 3초마다 프리펩 생성
        if(curTime >= 3)
        {
            SpawnObstacle();
        }
    }

    // 14개 정도 나옴.
    public void SpawnObstacle()
    {
        int direction = Random.Range(0, 2);
        // 왼쪽에 장애물 생성
        if (direction == 0)
        {
            Vector3 position = Player.transform.position;
            GameObject OL = (GameObject)Instantiate(Obstacle, position + new Vector3(-1.5f, -2f, -5), Quaternion.Euler(new Vector3(0, 180, 0)));
        }

        // 오른쪽에 장애물 생성
        else if (direction == 1)
        {
            Vector3 position = Player.transform.position;
            GameObject OR = (GameObject)Instantiate(Obstacle, position + new Vector3(1.5f, -2f, -5), Quaternion.Euler(new Vector3(0, 180, 0)));
        }

        curTime = 0;
    }
}
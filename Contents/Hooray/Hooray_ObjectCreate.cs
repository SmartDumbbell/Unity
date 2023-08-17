using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooray_ObjectCreate : MonoBehaviour
{
    public GameObject coin;
    public GameObject boom;
    public GameObject parent;

    public int objectcount = 10; // 오브젝트 연속 생성 개수

    public float longWaiting = 2f; // 주기 설정
    public float shortWaition = 0.0f; // 물체 사이의 간격
    // Start is called before the first frame update

    public Hooray_Gamemanager gameManager;

    //오브젝트 생성 함수
    public IEnumerator spawnObject()
    {
        while (true)
        {
            if (gameManager.isEnded) break;
            int rand = Random.Range(1, 3);
            for (int i = 0; i < objectcount; i++)
            {
                if (rand == 1)
                {
                    if (i == objectcount - 1)
                    {
                        parent = Instantiate(boom, transform.position + new Vector3(0, 0, 2.5f), transform.rotation);
                        parent.transform.parent = this.transform;
                        yield return new WaitForSeconds(shortWaition);
                        continue;
                    }
                    parent = Instantiate(coin, transform.position + new Vector3(0, 0, 2.5f), transform.rotation);
                    parent.transform.parent = this.transform;
                }
                else if (rand == 2)
                {
                    if (i == objectcount - 1)
                    {
                        parent = Instantiate(boom, transform.position + new Vector3(0, 0, -2.5f), transform.rotation);
                        parent.transform.parent = this.transform;
                        yield return new WaitForSeconds(shortWaition);
                        continue;
                    }
                    parent = Instantiate(coin, transform.position + new Vector3(0, 0, -2.5f), transform.rotation);
                    parent.transform.parent = this.transform;

                }
                yield return new WaitForSeconds(shortWaition);
            }
            yield return new WaitForSeconds(longWaiting);
        }
    }
}

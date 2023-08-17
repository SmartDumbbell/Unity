using UnityEngine;

public class Jumping_prefab_Moving : MonoBehaviour
{
    public float speed;
    GameObject gameManager;
    public GameObject coin;
    public GameObject boob;
    // Start is called before the first frame update
    void Start()
    {
/*        Time.timeScale = 0;*/
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        speed = gameManager.GetComponent<Jumping_GameManager>().speed;
        for (int i = 0; i < 10; i++)
        {
            MakeObjects(i);
        }
        //StartCoroutine(Moving());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
/*        if (Time.timeScale == 1)*/
            transform.position += new Vector3(0, 0, -1 * speed);
    }

/*    IEnumerator Moving()
    {
        while (true)
        {
            transform.position += new Vector3(0, 0, -1 * speed);
            yield return null;
        }
    }*/
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Erase"))
        {
            Destroy(gameObject);
        }
    }

    void MakeObjects(int pos)
    {
        if (Time.timeScale == 1)
        {
            if (Random.Range(0, 11) < gameManager.GetComponent<Jumping_GameManager>().makeProbability)
            {
                if (Random.Range(0, 11) > gameManager.GetComponent<Jumping_GameManager>().probability)
                {
                    Instantiate(coin, transform.position + transform.right * pos * 3 + transform.up * Random.Range(0, 3) * 2, transform.rotation);
                }
                else
                {
                    Instantiate(boob, transform.position + transform.right * pos * 3 + transform.up * Random.Range(0, 3) * 2, transform.rotation);
                }
            }
        }
    }
}

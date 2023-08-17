using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooray_ObjectMove : MonoBehaviour
{
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
        Destroy(this.gameObject,10f); // 5초뒤에 자동삭제
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        move();
    }

    private void move(){
        transform.position += new Vector3(0.2f,0,0);  //앞으로 날라옴
    }


}

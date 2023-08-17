using UnityEngine;

public class Jumping_wheel : MonoBehaviour
{
    void FixedUpdate()
    {
/*        if(Time.timeScale==1)*/
        transform.Rotate(15 *Vector3.left);
    }
}

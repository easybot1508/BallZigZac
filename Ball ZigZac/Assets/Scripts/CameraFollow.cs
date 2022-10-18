using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ball;
    Vector3 offset; //vi. tri' cua? bong - vi. tri cua? camera
    public float lerpRate;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position - transform.position;// khoang? cach giua~ camera va` ball 
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Folow();
        }
    }

    void Folow()
    {
        Vector3 pos = transform.position;//vi tri' hien. tai.
        Vector3 targetPos = ball.transform.position - offset; // vi. tri' ma` may anh? di den'
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime); // chuyen? doi? gia tri. theo ty le.

        transform.position = pos; // gan gia tri. nay` cho transform.position
    }
}

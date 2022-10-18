using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    Vector3 lastPos; //vi. tri' cuoi' cung` cua? platform,de tinh' toan' vi. tri' spawn tiep theo
    float size;//kich thuoc cua? platform

    public bool gameOver;


    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;//vi. tri' cuoi' cung` cua? platform
        size = platform.transform.localScale.x;//kich; thuoc' cua? platform 
        for(int i = 0; i< 20; i++)
        {
           SpawnPlatform();
        }

       
    }

    public void StartSpawningPlatform()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f);//sau 0.1s no se goi. ham` SpawnPlatform va` goi. di goi. lai. trong khoang 0.2s
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.intance.gameOver == true)
        {
            CancelInvoke("SpawnPlatform");
        }
    }


    void SpawnPlatform()
    {
       
        int random = Random.Range(0, 5);
        if(random < 3)
        {
            SpawnX();
        }
        else if(random >= 3)
        {
            SpawnZ();
        }
    }
    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;//vi. tri' platform spawn tiep theo
        Instantiate(platform, pos, Quaternion.identity);

        int random = Random.Range(0, 4); //random tu` gia tri. 0 den 4
        if(random < 1) // neu random vao` so 0 thi` se~ tao ra 1 diamond neu random vao` 1 2 3 thi` se~ ko tao. ra diamond
        {
            //khoi? tao. diamond, tai. vi. tri pos cua? platform, tai. y + them 1 , gan cho diamon vong` xoay da~ cho tu` truoc'
            Instantiate(diamond, new Vector3(pos.x,pos.y +1,pos.z), diamond.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int random = Random.Range(0, 4);
        if (random < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }
}

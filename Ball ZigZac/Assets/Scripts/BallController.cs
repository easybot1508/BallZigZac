using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle;
    [SerializeField] private float speed;
    bool started; // bien' luu tru~ xem tro` choi da bat dau` hay chua
    bool gameOver;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started) // tro` choi chua bat dau` , neu' nhan chuot. thi` tro` choi se~ bat' dau` them van. toc' cho ball
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.intance.StartGame();//day la` noi game bat dau`
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))//neu Ray khong va cham voi' gameObject
        {
            
            gameOver = true;
            rb.velocity = new Vector3(0, -25f , 0); // sau khi game over thi thay doi? van. toc' thao huong y cua? ball no' se~ rot xuong' 
            Camera.main.GetComponent<CameraFollow>().gameOver = true; // camera khong di chuyen theo bong khi bong roi xuong
            
            GameManager.intance.GameOver();//day la noi thuc su de tro` choi ket thuc' 
        }

        if(Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
       
           
    }

    public void SwitchDirection()
    {      
            if (rb.velocity.x > 0)
            {
                rb.velocity = new Vector3(0, 0, speed);
            }
            else if (rb.velocity.z > 0)
            {
                rb.velocity = new Vector3(speed, 0, 0);
            }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "Diamond")
        {
            //khoi? tao. particle tai.vi. tri cua? diamond , khong can` vong` xoay cho particle gan' cho bien part
           GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject; // vi1 luu tru~ part duoi dang game object nen phai them as GameObject    
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }
}

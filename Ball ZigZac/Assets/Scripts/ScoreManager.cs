using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager intance;
    public int score;
    public int highScore;

    private void Awake()
    {
        if(intance == null)
        {
            intance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score); // luu tru~ diem? vao` bien score duoi' dang. so nguyen va` duoi dang. tu` khoa' "score"
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementScore() // diem? tang
    {
        score += 1;
    }

    public void startScore()
    {
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }

    public void stopScore()
    {
        CancelInvoke("incrementScore");//ngung goi. ham` incrementScore

        //khi tro` choi dung` lai. thi` luu tru~ diem? vao` bien score theo dang. so nguyen
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))//tu` khoa' de luu tru~ diem? cao bat buoc phai? co de luu tru~ diem cao nhat
        {
            //neu co' san~ diem? cao naht roi` thi` kiem tra
            if(score > PlayerPrefs.GetInt("highScore"))// PlayerPrefs.GetInt("highScore") giup lay gia tri. co trong may' (diem cao)
            {
                PlayerPrefs.SetInt("highScore", score); // new diem cao hon diem? cao nhat thi` lay diem? do' luu thanh` diem cao nhat'
            }
        }
        else // neu chua co san~ diem? cao nhat trong may tinh thi` se~ luu diem? dau` tien lam` diem? cao nhat'
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}

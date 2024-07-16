using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    public float jumpForce;
    public TMP_Text score;
    public TMP_Text DeadText;
    public GameObject PressStart;

    private bool IsDeath;
    public static bool IsPlay;
    private int Score;
    private float DeadTime = 5f;

    private void Start()
    {
        IsDeath = false;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        GameObject scoreTxt = GameObject.Find("Score");
        DeadText = GameObject.Find("DeathText").GetComponent<TMP_Text>();
        PressStart = GameObject.Find("Press Start");
        if (scoreTxt != null)
            score = scoreTxt.GetComponent<TMP_Text>();
        IsPlay = false;
    }

    private void Update()
    {
        if (!IsPlay)
        {
            rb.velocity = new Vector3(0, 0, 0);
        }

        if (DeadTime <= 0)
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
        else if (IsDeath)
            DeadTime -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && !IsDeath)
        {
            rb.velocity = Vector2.up * jumpForce;
            PressStart.SetActive(false);
            IsPlay = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacles")
        {
            anim.SetBool("isDead", true);
            IsDeath = true;
            if (PlayerPrefs.HasKey("Score") && PlayerPrefs.GetInt("Score") < Score)
            {
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.Save();
            }
            else if (!PlayerPrefs.HasKey("Score"))
            {
                PlayerPrefs.SetInt("Score", Score);
                PlayerPrefs.Save();
            }
            DeadText.text = "You dead!\nWait 5 second";
            Score = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PointCheker")
        {
            Score++;
            score.text = "Score:" + Score.ToString();
        }
    }
}

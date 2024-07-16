using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public TMP_Text best;
    public GameObject PressStart;
    public AudioSource audio;

    private int Count;
    private void Start()
    {
        Count = 1;
        PressStart = GameObject.Find("Press Start");
        if (PlayerPrefs.HasKey("Score"))
            best.text = "Best:" + PlayerPrefs.GetInt("Score");
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!PressStart.activeSelf && Count == 1)
        {
            Count--;
            audio.Play();
        }
    }
}

using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = Mathf.Floor(timer % 60).ToString("00");

        _text.text = string.Format("{0}:{1}", minutes, seconds);
        
        if (timer < 0.0f)
        {
            GameManager.Instance.TriggerEndGame();
        }
    }
    
    
}

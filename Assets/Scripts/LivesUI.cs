using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [SerializeField] private Birdie birdie;
    public Image[] lives;
    
    void Update()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i].enabled = i < birdie.lives;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public float timer = 0;
    public TextMeshProUGUI textoTimer;
    void Update()
    {
        timer -= Time.deltaTime;
        textoTimer.text= "" +timer.ToString("f0");
    }
}

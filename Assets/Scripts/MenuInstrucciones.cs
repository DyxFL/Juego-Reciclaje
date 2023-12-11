using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInstrucciones : MonoBehaviour
{
    [SerializeField] private GameObject instrucciones;
    [SerializeField] private GameObject canvas1;

    void Start()
    {
        // Pausar el tiempo al iniciar el nivel
        Time.timeScale = 0f;
    }
      public void Reanudar(){
        Time.timeScale=1f;
        instrucciones.SetActive(false);
        canvas1.SetActive(true);
    }

}

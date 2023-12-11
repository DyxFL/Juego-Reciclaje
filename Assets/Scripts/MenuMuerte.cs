using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuMuerte : MonoBehaviour
{
   
    [SerializeField] private GameObject menuMuerte;
    private timer tiempo;

    
    private void Start(){
        tiempo=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<timer>();
        tiempo.MuerteJugador += ActivarMenu;
    }
    
    private void ActivarMenu(object sender,EventArgs e){
        //botonPausa.SetActive(false);
        Time.timeScale=0f;
        menuMuerte.SetActive(true);
    }
}

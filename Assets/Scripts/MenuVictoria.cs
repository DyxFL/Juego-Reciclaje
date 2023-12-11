using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuVictoria : MonoBehaviour
{
    [SerializeField] private GameObject menuVictoria;
    private ContainerLogic cl;
    private void Start(){
        cl=GameObject.FindGameObjectWithTag("Container").GetComponent<ContainerLogic>();
        cl.VictoriaJugador += ActivarMenu;
    }
    private void ActivarMenu(object sender,EventArgs e){
        //botonPausa.SetActive(false);
        Time.timeScale=0f;
        menuVictoria.SetActive(true);
    }
}

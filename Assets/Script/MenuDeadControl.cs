using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuDeadControl : MonoBehaviour
{
    public Button resetButton;  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnEnable ()  
    {  
        // Registra el evento del botón
        resetButton.onClick.AddListener ( () => buttonCallBack ());
    }  

    private void buttonCallBack ()  
    {  
        UnityEngine.Debug.Log ("Clicked: " + resetButton.name);   

        // Obtiene el nombre de la escena actual
        string scene = SceneManager.GetActiveScene ().name;  

        // Carga la escena
        SceneManager.LoadScene (scene, LoadSceneMode.Single); 
    }  
}

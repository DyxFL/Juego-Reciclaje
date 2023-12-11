using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DialogControl : MonoBehaviour
{
    public TextMeshProUGUI dialogueTextSeikleja;
    public TextMeshProUGUI dialogueTextTitulo;
    public Image dialogueImage; // Añadido para cambiar la imagen
    public string[] dialogues; // Array de diálogos
    public string[] titulos; // Array de títulos
    public Sprite[] imagenes; // Array de imágenes
    public int currentDialogueIndex = 0; // Índice del diálogo actual
    public int currentDialogueIndexTitulo = 0; // Índice del diálogo actual
    public float typingSpeed = 0.02f; // Velocidad de aparición del texto
    public GameObject[] paneles; // Array de paneles
    public GameObject canvas; // El canvas que contiene los diálogos
    public GameObject game; // Tu juego

    void Start()
    {
        Time.timeScale = 0; // Pausa el juego al inicio
        StartCoroutine(TypeDialogue());
    }

    IEnumerator TypeDialogue()
    {
        foreach (char letter in dialogues[currentDialogueIndex].ToCharArray())
        {
            dialogueTextSeikleja.text += letter; // Agrega una letra al texto del diálogo
            yield return new WaitForSeconds(typingSpeed); // Espera antes de agregar la siguiente letra
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Si se presiona la barra espaciadora
        {
            if (dialogueTextSeikleja.text == dialogues[currentDialogueIndex]) // Si el diálogo actual ha terminado
            {
                NextDialogue(); // Pasa al siguiente diálogo
            }
            else
            {
                SkipDialogue(); // Si el diálogo actual no ha terminado, lo salta
            }
        }
    }

    void NextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length-1)
        {
            currentDialogueIndex++;
            dialogueTextSeikleja.text = "";
            // Cambia el título en los diálogos 3, 6, 9, 12, 15 y 18
            if (currentDialogueIndex % 3 == 0 && currentDialogueIndexTitulo < titulos.Length)
            {
                dialogueImage.sprite = imagenes[currentDialogueIndexTitulo];
                dialogueTextTitulo.text = titulos[currentDialogueIndexTitulo];
                paneles[currentDialogueIndexTitulo].SetActive(true); // Activa el panel correspondiente
                if (currentDialogueIndexTitulo > 0)
                {
                    paneles[currentDialogueIndexTitulo - 1].SetActive(false); // Desactiva el panel anterior
                }
                currentDialogueIndexTitulo++;
            }
            StartCoroutine(TypeDialogue());
        }
        else
        {
            canvas.SetActive(false); // Desactiva el canvas
            game.SetActive(true); // Activa el juego
            Time.timeScale = 1; // Reanuda el juego
        }
    }

    void SkipDialogue()
    {
        StopCoroutine(TypeDialogue());
        dialogueTextSeikleja.text = "";
        dialogueTextSeikleja.text = dialogues[currentDialogueIndex];
        StopCoroutine(TypeDialogue());
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ContainerLogic : MonoBehaviour
{
    public event EventHandler VictoriaJugador;
    public float scorePerItem = 10f; // Puntaje por cada objeto depositado
    public TextMeshProUGUI scoreText; // Referencia al texto donde se mostrará el puntaje

    private float currentScore = 0f;
    public Inventory inventory;

    private void Start()
    {
        UpdateScoreText();
    }

    public void DepositItem(GameObject depositedObject)
    {
        currentScore += scorePerItem;
        UpdateScoreText();
        inventory.RemoveItem(depositedObject);
       

        // Si se removió el objeto del inventario, actualiza el estado de las posiciones vacías
        
        for (int i = 0; i < inventory.isFull.Length; i++)
        {
            if (!inventory.isFull[i])
            {
                inventory.isFull[i] = true; // Marca como lleno nuevamente
                break;
            }
        }
    }
    void UpdateInventoryStatus()
    {
        // Recorre el inventario y marca las posiciones vacías
        for (int i = 0; i < inventory.isFull.Length; i++)
        {
            if (inventory.slots[i] == null)
            {
                inventory.isFull[i] = false; // Marca como vacío si el slot no tiene un objeto
            }
        }
    }
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntaje: " + currentScore.ToString()+"/100";
            if(scoreText.text=="Puntaje: 100/100")
            {
                VictoriaJugador?.Invoke(this,EventArgs.Empty);
            }
        }

    }
}

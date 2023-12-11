using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public KeyCode pickupKey = KeyCode.E; // Tecla para recoger items

    public TextMeshProUGUI pickupText;

    private bool canPickUp = false; // Variable para controlar la recolección

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        pickupText.gameObject.SetActive(false);
    }

    private void Update()
    {
        // Verificar si el jugador está cerca y presiona la tecla para recoger items
        if (canPickUp && Input.GetKeyDown(pickupKey))
        {
            PickUpItem();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true; // Permitir la recolección cuando el jugador esté cerca
            pickupText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = false; // Evitar la recolección cuando el jugador se aleje
            pickupText.gameObject.SetActive(false);
        }
    }

    void PickUpItem()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (!inventory.isFull[i])
            {
                inventory.isFull[i] = true;

                Instantiate(itemButton, inventory.slots[i].transform, false);
                
                Destroy(gameObject);
                pickupText.gameObject.SetActive(false);
                break;
            }
        }
    }
}

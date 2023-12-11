using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    // Agregar un objeto al inventario
    public bool AddItem(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!isFull[i])
            {
                slots[i] = item;
                isFull[i] = true;
                item.transform.SetParent(transform); // Asegúrate de establecer el padre del objeto al inventario
                item.SetActive(false); // Opcional: desactivar el objeto para que no sea visible en el inventario
                return true;
            }
        }
        return false; // El inventario está lleno
    }

    // Quitar un objeto del inventario
    public bool RemoveItem(GameObject item)
    {
        
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == item)
            {
                
                isFull[i] = false;
                return true;
                
            }
        }
        return false; // El objeto no está en el inventario
    }
}

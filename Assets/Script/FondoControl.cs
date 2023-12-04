using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoControl : MonoBehaviour
{
    public float speed = 1.0f; // Velocidad de movimiento
    private float spriteHeight; // Altura del sprite

    void Start()
    {
        // Obtenemos la altura del sprite
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }
    void Update()
    {
        Vector3 position = transform.position; // Obtenemos la posición actual del sprite

        position.y += speed * Time.deltaTime; // Añadimos a la posición en el eje y la velocidad multiplicada por el tiempo transcurrido desde el último frame

        // Si el sprite ha pasado su altura
        if (position.y <= -32)
        {
            // Reiniciamos la posición del sprite
            position.y += spriteHeight-31;
        }
        transform.position = position; // Asignamos la nueva posición al sprite
    }
}

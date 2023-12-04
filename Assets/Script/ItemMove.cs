using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del objeto
    private float limiteInferior = -10f; // Límite inferior de la pantalla

    void Update()
    {
        // Mover el objeto hacia abajo
        transform.position += new Vector3(0, -velocidad * Time.deltaTime, 0);

        // Si el objeto alcanza el límite inferior de la pantalla, lo destruye
        if (transform.position.y < limiteInferior)
        {
            Destroy(gameObject);
        }
    }
}

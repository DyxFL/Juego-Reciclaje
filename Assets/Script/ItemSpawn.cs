using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public List<GameObject> prefabs; // La lista de objetos prefabricados que quieres generar
    public float tiempoEntreGeneraciones = 1f; // El tiempo entre cada generación de objetos
    private float limiteIzquierdo = -9f; // Límite izquierdo de la pantalla
    private float limiteDerecho = 9f; // Límite derecho de la pantalla

    void Start()
    {
        // Comienza a generar objetos
        StartCoroutine(GenerarObjetos());
    }

    IEnumerator GenerarObjetos()
    {
        while (true)
        {
            // Genera un objeto en una posición aleatoria en la parte superior de la pantalla
            float posicionAleatoriaX = Random.Range(limiteIzquierdo, limiteDerecho);
            Vector3 posicionGeneracion = new Vector3(posicionAleatoriaX, transform.position.y+5, transform.position.z);

            // Selecciona un prefabricado aleatorio de la lista
            GameObject prefabSeleccionado = prefabs[Random.Range(0, prefabs.Count)];

            // Genera el objeto
            Instantiate(prefabSeleccionado, posicionGeneracion, Quaternion.identity);

            // Espera el tiempo especificado antes de generar el próximo objeto
            yield return new WaitForSeconds(tiempoEntreGeneraciones);
        }
    }
}
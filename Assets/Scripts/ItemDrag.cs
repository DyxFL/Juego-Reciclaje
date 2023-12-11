using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Inventory inventory;
    private bool isDragging = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
        inventory = FindObjectOfType<Inventory>(); // Asegúrate de ajustar esta búsqueda según cómo tengas configurado tu inventario
        //itemButton = transform.Find("button").gameObject;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (inventory != null)
        {
            /*if (inventory.RemoveItem(gameObject))
            {
                transform.SetParent(canvas.transform, true);
                isDragging = true;
            }*/
            // Al iniciar el arrastre, no necesitas eliminar el objeto del inventario
            // Simplemente establece que ya no está siendo ocupado en el inventario
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.slots[i] == gameObject)
                {
                    inventory.isFull[i] = false; // Marca el slot como vacío
                    break;
                }
            }

            transform.SetParent(canvas.transform, true);
            isDragging = true;

        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            isDragging = false;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Container"))
            {
                // Agregar lógica para depositar el objeto en el contenedor
                // Por ejemplo, incrementar el puntaje y destruir el objeto
                Destroy(gameObject);
                hit.collider.GetComponent<ContainerLogic>().DepositItem(gameObject);
              
            }
            else
            {
                // Si no se suelta en el contenedor, regresar al inventario
                transform.SetParent(inventory.transform, false);
                inventory.AddItem(gameObject);
                
            }
        }
    }
}

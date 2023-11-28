using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public float speed = 5.0f;
    public Sprite[] sprites; // Array de sprites para cambiar el aspecto del personaje
    
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private SpriteRenderer spriteRenderer; // Componente para renderizar el sprite

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spriteRenderer = this.GetComponent<SpriteRenderer>(); // Obtener el componente SpriteRenderer
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalInput, verticalInput) * speed;
        
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x), Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y));
        
        // Cambiar el sprite del personaje al presionar las teclas Y, U, I, O, P
        if (Input.GetKeyDown(KeyCode.Y))
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            spriteRenderer.sprite = sprites[3];
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            spriteRenderer.sprite = sprites[4];
        }
    }
}


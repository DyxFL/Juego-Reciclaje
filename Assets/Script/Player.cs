using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class Score
{
    public string tag;
    public int value;
}

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public Sprite[] sprites; // Array de sprites para cambiar el aspecto del personaje
    public int lives = 5; // Vidas del jugador
    public List<Score> scores; // Lista de puntajes para mostrar en el inspector
    public TextMeshProUGUI noReciclaText;
    public TextMeshProUGUI vidrioText;
    public TextMeshProUGUI cartonText;
    public TextMeshProUGUI organicoText;
    public TextMeshProUGUI plasticoText;
    public Rigidbody2D[] vida;


    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private SpriteRenderer spriteRenderer;
    private string currentTag; // Tag del objeto que el jugador puede recoger
    private Dictionary<Sprite, string> spriteTagMap; // Diccionario para mapear los sprites a los tags de los objetos
    private Dictionary<string, int> scoreMap; // Diccionario para llevar la puntuación de cada tipo de objeto
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spriteRenderer = this.GetComponent<SpriteRenderer>(); // Obtener el componente SpriteRenderer

        // Inicializar el diccionario
        spriteTagMap = new Dictionary<Sprite, string>
        {
            { sprites[0], "NoRecicla" },
            { sprites[1], "Vidrio" },
            { sprites[2], "Carton" },
            { sprites[3], "Organico" },
            { sprites[4], "Plastico" }
        };

        // Inicializar el diccionario de puntajes
        scoreMap = new Dictionary<string, int>();
        foreach (Score score in scores)
        {
            scoreMap[score.tag] = score.value;
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalInput, verticalInput) * speed;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x),
            Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y));
        if (lives < 0)
        {
            Destroy(gameObject);
        }
        // Cambiar el sprite del personaje al presionar las teclas Y, U, I, O, P
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSprite(sprites[0]);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            ChangeSprite(sprites[1]);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeSprite(sprites[2]);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            ChangeSprite(sprites[3]);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeSprite(sprites[4]);
        }
        //Rotación
        if(horizontalInput == 0) return;
        if (horizontalInput < 0)
        {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
        currentTag = spriteTagMap[sprite];
    }
    IEnumerator MoveLifeOffScreen(Rigidbody2D life)
    {
        while (life.transform.position.x > -10) // Asume que -10 es el límite izquierdo de la pantalla
        {
            life.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0); // Mover a la izquierda
            
            yield return null; // Esperar al siguiente frame
        }
        Destroy(life.gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == currentTag)
        {
            scoreMap[currentTag]++; // Aumentar la puntuación para el tipo de objeto actual
            // Actualizar el valor en la lista scores
            foreach (Score score in scores)
            {
                if (score.tag == currentTag)
                {
                    score.value = scoreMap[currentTag];
                    break;
                }
            }

            // Actualizar los textos de los puntajes
            noReciclaText.text = "" + scoreMap["NoRecicla"];
            vidrioText.text = "" + scoreMap["Vidrio"];
            cartonText.text = "" + scoreMap["Carton"];
            organicoText.text = "" + scoreMap["Organico"];
            plasticoText.text = "" + scoreMap["Plastico"];
            Destroy(collision.gameObject); // Destruir el objeto
        }
        else if (collision.gameObject.tag == "Arbol")
        {
            lives--; // Disminuir las vidas
            if (lives >= 0)
            {
                vida[lives].transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0)); // Girar la vida en el eje x
                vida[lives].GetComponent<Animator>().SetBool("isRun", true);
                StartCoroutine(MoveLifeOffScreen(vida[lives])); // Iniciar la corutina para mover la vida

            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "PowerUp")
        {
            speed++; // Aumentar la velocidad
            Destroy(collision.gameObject); // Destruir el objeto
        }
        else
        {
            lives--; // Disminuir las vidas cuando el color no corresponde
            if (lives >= 0)
            {
                vida[lives].transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0)); // Girar la vida en el eje x
                vida[lives].GetComponent<Animator>().SetBool("isRun", true);
                StartCoroutine(MoveLifeOffScreen(vida[lives])); // Iniciar la corutina para mover la vida
            }
            Destroy(collision.gameObject);
        }
    }
}
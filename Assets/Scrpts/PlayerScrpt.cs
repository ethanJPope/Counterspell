using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScrpt : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject shadow;
    private float move;
    public float speed;
    public float jump;
    bool istouchingGround;
    public bool dead = false;
    public float startTime = 5f;
    float timer = 0;
    public GameObject text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= startTime) {
            shadow.SetActive(true);
        }
        else {
            timer = timer + Time.deltaTime;
        }
        move = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(move * speed * Time.deltaTime, rb.linearVelocity.y);
        if(Input.GetButtonDown("Jump")) {
            if(istouchingGround) {
                rb.AddForce(new Vector2(rb.linearVelocity.x, jump * 10));
            }
        }

        if(dead == true) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            dead = false;
        }
    }
    private void OnCollisionEnter2D (Collision2D collision2D) {
        if(collision2D.gameObject.CompareTag("Ground")) {
            istouchingGround = true;
        }

        if(collision2D.gameObject.CompareTag("DeathBlocks")) {
            Vector3 normal = collision2D.GetContact(0).normal;
            if(normal == Vector3.up) {
                dead = true;
            }
        }

        if(collision2D.gameObject.CompareTag("Shadow")) {
            dead = true;
            
        }
        if(collision2D.gameObject.CompareTag("Elevator1")) {
            text.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision2D) {
        if(collision2D.gameObject.CompareTag("Ground")) {
            istouchingGround = false;
        }

    }

}

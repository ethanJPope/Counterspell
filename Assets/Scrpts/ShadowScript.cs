using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadowScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    public float speed;
    public float jump;
    bool istouchingGround;
    public bool dead = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void OnCollisionExit2D(Collision2D collision2D) {
        if(collision2D.gameObject.CompareTag("Ground")) {
            istouchingGround = false;
        }
    }

}

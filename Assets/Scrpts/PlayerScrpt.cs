using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerScrpt : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject shadow;
    public Animator animator;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public BoxCollider2D feet;

    private float move;
    public float speed;
    public float jump;
    bool istouchingGround;
    bool dead = false;
    public float startTime = 5f;
    float timer = 0;
    public GameObject text;
    bool movement = false;
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

        animator.SetFloat("speed", Math.Abs(move));
        animator.SetBool("isJumping", istouchingGround == false);
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        if(Input.GetButtonDown("Jump")) {
            if(istouchingGround) {

                rb.AddForce(new Vector2(rb.linearVelocity.x, jump * 10));
                SoundFXManager.instance.PlaySoundFXClip(jumpSound, transform, 1f);
            }
        }

        if(dead == true) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            dead = false;
        }

        if(feet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            istouchingGround = true;
        }
        if(feet.IsTouchingLayers(LayerMask.GetMask("DeathBlocks"))) {
            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 1f);
            Invoke("playerDies", 0.1f);
        }
    }
    private void OnCollisionEnter2D (Collision2D collision2D) {
        if(collision2D.gameObject.CompareTag("Shadow")) {
            SoundFXManager.instance.PlaySoundFXClip(deathSound, transform, 1f);
            Invoke("playerDies", 0.1f);
            
        }
        if(collision2D.gameObject.CompareTag("Elevator1")) {
        SceneManager.LoadScene("Scenes/Level2");        }
    }

    private void OnCollisionExit2D(Collision2D collision2D) {
        if(collision2D.gameObject.CompareTag("Ground")) {
            istouchingGround = false;
        }

    }
    private void playerDies() {
        dead = true;
    }
}

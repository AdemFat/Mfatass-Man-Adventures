 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Image healthImage;
    public float Health;
    public float maxHealth;
    public GameObject LosingMessage;
    public float speed, jumpforce;
    private float xInput;
    private Rigidbody2D rb;
    bool jump;
    Animator animator;
    public GameObject restartButton;
    public int CoinsScore;
    public TextMeshProUGUI CoinsScoreDisplay;

    private void Start()
    {
        Debug.Log(name);
        restartButton.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthImage.fillAmount = Health / maxHealth;
    }

    void Update()
    {

        xInput = Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = new Vector2(xInput, rb.velocity.y);

        animator.SetBool("running", xInput!= 0);
        animator.SetBool("IsJumping", rb.velocity.y != 0);

        if (Input.GetButtonDown("Jump")&&!jump)
        {
            jump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            characterScale.x = -1.362961f;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            characterScale.x = 1.362961f;
        }
        transform.localScale = characterScale;

        if (CoinsScoreDisplay.text != CoinsScore.ToString())
        {
            CoinsScoreDisplay.text = CoinsScore.ToString();
        }

        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("IsJumping", false);

        if (collision.gameObject.tag == "Ground")
        {
            jump = false;

        }
        if(collision.gameObject.tag == "Saw")
        {
            DamageMe();

        }
        
        if(collision.gameObject.tag == "Bullet")
        {
            DamageMe();
        }
        if (collision.gameObject.tag == "shoukk")
        {
            KillMeNow();
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            CoinsScore++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Health"))
        {
            if (Health <= maxHealth) {
                Health = maxHealth;
                healthImage.fillAmount = Health / maxHealth;
            }
            
        }
        if(other.gameObject.tag == "Chest")
        {
            other.GetComponent<Animator>().SetBool("open", true);
        }
    }

    public void KillMeAfterAwhile()
    {
        Invoke("KillMeNow", 3);
    }

    public void KillMeNow()
    {
        Health = 0;
        healthImage.fillAmount = Health / maxHealth;
        LosingMessage.SetActive(true);
        restartButton.SetActive(true);
        gameObject.SetActive(false);

    }

    public void DontKillMe()
    {
        CancelInvoke("KillMeNow");
    }

    public void DamageMe()
    {
        Health--;
        healthImage.fillAmount = Health / maxHealth;

        if (Health <= 0)
        {
            KillMeNow();

        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    
}

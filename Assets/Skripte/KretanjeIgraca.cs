using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KretanjeIgraca : MonoBehaviour
{
    
    public float brzina; 
    private float Kretanje; 
    public Vector2 velicinaKutije; 
    public float udaljenostBacanja; 
    public LayerMask slojTlo; 
    private Rigidbody2D rb; 
    private Animator animator; 

    public bool jeProšaoPortal = false;

    public bool jeCrveniIgrac = false;

    public enum TipIgraca { Mali, Srednji, Veliki }
    public TipIgraca tipIgraca;

    private float visinaSkokaMali = 8.5f;
    private float visinaSkokaSrednji = 10;
    private float visinaSkokaVeliki = 8.2f;


    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kutija") && jeCrveniIgrac)
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>() == null)
            {
                collision.gameObject.AddComponent<Rigidbody2D>();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kutija") && jeCrveniIgrac)
        {
            Rigidbody2D kutijaRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (kutijaRb != null)
            {
                Destroy(kutijaRb);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        Kretanje = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(brzina * Kretanje, rb.velocity.y);

        animator.SetBool("aktivacijaTrcanje", Kretanje != 0);

        if (Input.GetButtonDown("Jump") && naTlu())
        {

            if (audioSource != null)
            {
                audioSource.Play();
            }

        float skok = 0;

        switch (tipIgraca)
        {
            case TipIgraca.Mali:
                skok = visinaSkokaMali;
                break;
            case TipIgraca.Srednji:
                skok = visinaSkokaSrednji;
                break;
            case TipIgraca.Veliki:
                skok = visinaSkokaVeliki;
                break;
            }

        rb.velocity = new Vector2(rb.velocity.x, skok);
        }
    }

    public bool naTlu()
    {

        if (Physics2D.BoxCast(transform.position, velicinaKutije, 0, -transform.up, udaljenostBacanja, slojTlo))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * udaljenostBacanja, velicinaKutije);
    }

   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Siljci")
        {
            Destroy(gameObject);
            Scene trenutnaScena = SceneManager.GetActiveScene();
            SceneManager.LoadScene(trenutnaScena.buildIndex);
            Debug.Log("Igraè je mrtav!");
        }
    }
}

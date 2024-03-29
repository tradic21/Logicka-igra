using UnityEngine;
using UnityEngine.SceneManagement;

public class Metak : MonoBehaviour
{
    public float brzina;
    private Rigidbody2D rb;


    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * brzina;

        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        KretanjeIgraca igrac = collision.gameObject.GetComponent<KretanjeIgraca>();
        if (igrac != null && igrac.tipIgraca != KretanjeIgraca.TipIgraca.Veliki)
        {
            Destroy(collision.gameObject);
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
        Destroy(gameObject);
    }
}

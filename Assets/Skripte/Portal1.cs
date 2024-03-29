using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal1 : MonoBehaviour
{
    public PromjenaIgraca promjenaIgraca;
    private int brojIgracaProsao = 0;
    private const int ukupnoIgraca = 3;



    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Igrac"))
        {
            collision.gameObject.SetActive(false);
            brojIgracaProsao++;

            //collision.GetComponent<KretanjeIgraca>().jeProšaoPortal = true;

            if (brojIgracaProsao >= ukupnoIgraca)
            {
                Debug.Log("Prošli ste level!");
                SceneManager.LoadScene("Level2");
            }
            else
            {
                promjenaIgraca.ZamjenaIgraca();
            }
        }
    }
}
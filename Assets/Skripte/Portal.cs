using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public PromjenaIgraca promjenaIgraca;
    private int brojIgracaProsao = 0;
    private const int ukupnoIgraca = 3;

    

    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Igrac")) 
        {
            other.gameObject.SetActive(false); // Deaktiviraj igra�a
            brojIgracaProsao++;

            other.GetComponent<KretanjeIgraca>().jePro�aoPortal = true;

            if (brojIgracaProsao >= ukupnoIgraca)
            {
                Debug.Log("Pro�li ste level!");
                SceneManager.LoadScene("Level3");
            }
            else
            {
                promjenaIgraca.ZamjenaIgraca();
            }
        }
    }
}
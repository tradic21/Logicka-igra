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
            other.gameObject.SetActive(false); // Deaktiviraj igraèa
            brojIgracaProsao++;

            other.GetComponent<KretanjeIgraca>().jeProšaoPortal = true;

            if (brojIgracaProsao >= ukupnoIgraca)
            {
                Debug.Log("Prošli ste level!");
                SceneManager.LoadScene("Level3");
            }
            else
            {
                promjenaIgraca.ZamjenaIgraca();
            }
        }
    }
}
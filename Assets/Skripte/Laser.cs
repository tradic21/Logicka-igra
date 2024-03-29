using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Igrac"))
        {
            Destroy(collision.gameObject);
            Scene trenutnaScena = SceneManager.GetActiveScene();
            SceneManager.LoadScene(trenutnaScena.buildIndex);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KontrolerScena : MonoBehaviour
{
    public static KontrolerScena instanca;

    private void Awake()
    {
        if(instanca == null)
        {
            instanca = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SljedeciLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void UcitajScenu(string imeScene)
    {
        SceneManager.LoadScene(imeScene);
    }
}

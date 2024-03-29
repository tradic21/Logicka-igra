using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TranzicijaScena : MonoBehaviour
{
    private Animator tranzicijaAnim;

    // Start is called before the first frame update
    void Start()
    {
        tranzicijaAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UcitavanjeScene(string imeScene)
    {
        StartCoroutine(Tranzicija(imeScene));
    }

    IEnumerator Tranzicija(string imeScene)
    {
        tranzicijaAnim.SetTrigger("Kraj");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(imeScene);
    }


}

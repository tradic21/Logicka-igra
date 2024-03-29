using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ispaljivac : MonoBehaviour
{
    public Transform mjestoIspaljivanja;
    public GameObject metak;
    float vrijemeIzmedu;
    public float pocetnoVrijemeIzmedu;

    // Start is called before the first frame update
    void Start()
    {
        vrijemeIzmedu = pocetnoVrijemeIzmedu;
    }

    // Update is called once per frame
    void Update()
    {
        if (vrijemeIzmedu <= 0)
        {
            Instantiate(metak, mjestoIspaljivanja.position, mjestoIspaljivanja.rotation);

            vrijemeIzmedu = pocetnoVrijemeIzmedu;
        }
        else
        {
            vrijemeIzmedu -= Time.deltaTime;
        }
    }


}
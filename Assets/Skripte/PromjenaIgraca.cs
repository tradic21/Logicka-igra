using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromjenaIgraca : MonoBehaviour
{
    public KretanjeIgraca igrac1Kontroler;
    public KretanjeIgraca igrac2Kontroler;
    public KretanjeIgraca igrac3Kontroler;
    private int trenutniIgrac = 1;

    public GameObject trokutIgraca1; 
    public GameObject trokutIgraca2; 
    public GameObject trokutIgraca3; 

    private void Start()
    {
        AktivirajIgraca(1);
    }

    private void AktivirajIgraca(int brojIgraca)
    {
        igrac1Kontroler.enabled = false;
        igrac2Kontroler.enabled = false;
        igrac3Kontroler.enabled = false;

        trokutIgraca1.SetActive(false);
        trokutIgraca2.SetActive(false);
        trokutIgraca3.SetActive(false);

        switch (brojIgraca)
        {
            case 1:
                igrac1Kontroler.enabled = true;
                trokutIgraca1.SetActive(true);
                break;
            case 2:
                igrac2Kontroler.enabled = true;
                trokutIgraca2.SetActive(true);
                break;
            case 3:
                igrac3Kontroler.enabled = true;
                trokutIgraca3.SetActive(true);
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            ZamjenaIgraca();
        }
    }

    public void ZamjenaIgraca()
    {
        trenutniIgrac = (trenutniIgrac % 3) + 1;

        AktivirajIgraca(trenutniIgrac);
    }
}
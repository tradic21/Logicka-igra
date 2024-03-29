using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrzacKljuceva : MonoBehaviour
{
    private List<Kljuc.TipKljuca> kljucList;

    private void Awake()
    {
        kljucList = new List<Kljuc.TipKljuca>();
    }

    public void DodajKljuc(Kljuc.TipKljuca tipKljuca)
    {
        kljucList.Add(tipKljuca);
    }

    public void UkloniKljuc(Kljuc.TipKljuca tipKljuca)
    {
        kljucList.Remove(tipKljuca);
    }

    public bool SadrziKljuc(Kljuc.TipKljuca tipKljuca)
    {
        return kljucList.Contains(tipKljuca);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Kljuc kljuc = collision.GetComponent<Kljuc>();
        if (kljuc != null)
        {
            DodajKljuc(kljuc.DohvatiTipKljuca());
            Destroy(kljuc.gameObject);
        }

        Vrata vrata = collision.GetComponent<Vrata>();
        if(vrata != null)
        {
            if (SadrziKljuc(vrata.DohvatiTipKljuca()))
            {
                UkloniKljuc(vrata.DohvatiTipKljuca());
                vrata.OtvoriVrata();

            }
        }
    }
}

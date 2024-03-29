using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vrata : MonoBehaviour
{
    [SerializeField] private Kljuc.TipKljuca tipKljuca;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public Kljuc.TipKljuca DohvatiTipKljuca()
    {
        return tipKljuca;
    }

    public void OtvoriVrata()
    {
        anim.SetTrigger("Otvori");

    }
}

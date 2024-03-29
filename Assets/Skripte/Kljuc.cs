using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kljuc : MonoBehaviour
{
    [SerializeField] private TipKljuca tipKljuca;

    public enum TipKljuca
    {
        Kljuc,
        Kljuc1
    }

    public TipKljuca DohvatiTipKljuca()
    {
        return tipKljuca;
    }
    
}

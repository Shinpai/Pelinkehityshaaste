using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite noppakuva;
    public float K, S, P;
    public string tulos;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = noppakuva;
    }

    public void setKSP(int ki, int sa, int pa)
    {
        K = ki; S = sa; P = pa;
    }

    public void RollMe()
    {
        var factor = 1 / (K + S + P);
        float _K = K * factor;
        float _S = S * factor;
        float _P = P * factor;

        var r = Random.Range(0f, 1f);

        // sort for cumulative
        var arr = new[] { _K, _S, _P };
        System.Array.Sort(arr);

        // valitaan tuloksen ja kumulatiivisen todnäk mukaan tulos
        float valittu;
        if (r < arr[0])
            valittu = arr[0];
        else if (r < arr[1])
            valittu = arr[1];
        else
            valittu = arr[2];

        // palautetaan oikea tulos
        if (valittu == _K)
        {
            tulos = "Kivi";
        }   
        else if (valittu == _P)
        {
            tulos = "Paperi";
        }   
        else if (valittu == _S)
        {
            tulos = "Sakset";
        }
    }
}

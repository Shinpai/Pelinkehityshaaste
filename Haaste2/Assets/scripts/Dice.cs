using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public float K, S, P;
    public string tulos = "0";
    public GameObject pool, box;
    public Sprite k, s, p;
    public bool tavoite_flag = false;

    private void Awake()
    {
        box = GameObject.Find("DiceGrid");
        pool = GameObject.Find("DicePool");
    }

    private void Update()
    {
        if (tulos == "Kivi")
            GetComponent<Image>().sprite = k;
        else if (tulos == "Sakset")
            GetComponent<Image>().sprite = s;
        else if (tulos == "Paperi")
            GetComponent<Image>().sprite = p;
    }

    public void setKSP(int ki, int sa, int pa)
    {
        K = ki; S = sa; P = pa;
    }

    public string RollMe()
    {
        var heitto = Random.Range(1, 7);
        Debug.Log(heitto + " heitetty");
        if (heitto <= 2)
            tulos = "Kivi";
        else if (2 <= heitto && heitto <= 4)
            tulos = "Sakset";
        else if (4 <= heitto && heitto <= 6)
            tulos = "Paperi";
        return tulos;
    }

    public string RollMeFactored()
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

        return tulos;
    }
        
    public void AddOrRemoveFromPool()
    {
        if (transform.parent.gameObject == box && !tavoite_flag)
        {
            if (pool.transform.childCount > 5)
                return;
            Debug.Log("from box to pool");
            GameObject newGO = Instantiate(gameObject);
            newGO.transform.SetParent(pool.transform);
            newGO.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (!tavoite_flag)
        {
            Debug.Log("from pool to box");
            Destroy(gameObject);
        }
    }
}

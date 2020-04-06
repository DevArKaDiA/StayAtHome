using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDinero : MonoBehaviour
{
    public Image fill;
    public Color barra70, barra50, barra30, barra0;
    Slider barra;
    public float bien, pasable, noTanMal, mal;
    // Start is called before the first frame update
    void Start()
    {
        barra = GetComponent<Slider>();
        bien = barra.maxValue * 70 / 100;
        pasable = barra.maxValue * 50 / 100;
        noTanMal = barra.maxValue * 30 / 100;
        mal = barra.maxValue * 0 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (barra.value >= bien)
        {

            CambiarColor(barra70);

        }
        else if (barra.value >= pasable)
        {

            CambiarColor(barra50);

        }
        else if (barra.value >= noTanMal)
        {

            CambiarColor(barra30);

        }
        else
        {
            CambiarColor(barra0);
        }
    }
    public void CambiarColor(Color auxColor)
    {
        fill.color = auxColor;
    }
}

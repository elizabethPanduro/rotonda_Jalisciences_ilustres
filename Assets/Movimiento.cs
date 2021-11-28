using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 esquinaII, esquinaSI, esquinaSD, esquinaID;
    public float velocidad = 1, tiempoPunto = 5,Cronometro = 0,Alto = 128, EsperaInicial = 26;
    public TextMeshProUGUI UI;
    private float ContadorTiempo;
    private int puntos;

    void settextComoPunto()
    {
        UI.text = "Puntaje: " + puntos.ToString();
    }


    void Start()
    {
        puntos = -1;
        ContadorTiempo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (EsperaInicial > 0)
            EsperaInicial = EsperaInicial - Time.deltaTime;
        else
        if (Cronometro < Alto)
        {
            ContadorTiempo = ContadorTiempo + Time.deltaTime;
            Cronometro = Cronometro + Time.deltaTime;
            if (transform.position.x < esquinaII.x && transform.position.z >= esquinaII.z)
            {

                transform.position = transform.position + new Vector3(velocidad * Time.deltaTime, 0, 0);
            }
            else
                if (transform.position.z >= esquinaSI.z && transform.position.x >= esquinaSI.x)
            {

                transform.position = transform.position + new Vector3(0, 0, -1 * velocidad * Time.deltaTime);
            }
            else
                if (transform.position.x >= esquinaSD.x && transform.position.z < esquinaSD.z)
            {

                transform.position = transform.position + new Vector3(-1 * velocidad * Time.deltaTime, 0, 0);
            }
            else
                if (transform.position.x < esquinaID.x && transform.position.z < esquinaID.z)
            {

                transform.position = transform.position + new Vector3(0, 0, velocidad * Time.deltaTime);
            }
            if (ContadorTiempo > tiempoPunto)
            {
                ContadorTiempo = 0;
                puntos++;
                settextComoPunto();
            }
        }
        else
        {
            UI.text = "Fin del recorrido";
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject puzzlePiece;
    private GameObject[,] grid;
    bool jugador = false;
    int turno;
    int puntosJugador1 = 1;
    int puntosJugador2 = 1;
    public Text Jugador1;
    public Text Jugador2;
    public Text Jugador1_bonus;
    public Text Jugador2_bonus;
    double bonus = .6;
    //public Text Ganador;
    public Text JugadorGanador1;
    public Text JugadorGanador2;
    double puntosParaGanar = 20;
    bool limiteDeJuego;
    private int[,] colores = new int[6, 6];

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject go = GameObject.Instantiate(puzzlePiece) as GameObject;
                Vector3 position = new Vector3(x, y, 0);
                go.transform.position = position;
                grid[x, y] = go;
                colores[x, y] = 0;
            }
        }

    }

    private void Awake()
    {
        //Ganador.gameObject.SetActive(false);
        JugadorGanador1.gameObject.SetActive(limiteDeJuego);
        JugadorGanador2.gameObject.SetActive(limiteDeJuego);


    }
    // Update is called once per frame
    void Update()
    {
        Vector3 mPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        bool click = Input.GetMouseButtonDown(0);
        Color colorEsferaPrevia = Color.clear;
        Color colorEsferaActual = Color.clear;
        Color colorEsfera3 = Color.clear;
        int x = (int)(mPosition.x + 0.5f);
        int y = (int)(mPosition.y + 0.5f);
        ComparadorDeColores comparadorDeColores = new ComparadorDeColores();
        if (click && limiteDeJuego == false)
        {
            GameObject esferaActual1 = grid[x, y];
            Color base1 = esferaActual1.GetComponent<Renderer>().material.color;
            Color colorSwitch = Color.white;
            if (base1 == colorSwitch)
            {
                if (jugador == true)
                {
                    turno = 1;
                    UpdatePickedPiece(mPosition, turno);

                    int xEsferaAnterior = x - 1;
                    int yEsferaActual = y;
                    Debug.Log("El valor del color en " + " x = " + x + "y = " + y + " es " + colores[x, y]);

                    colores[x, y] = 1;
                    Debug.Log("El valor del color en " + " x = " + x + "y = " + y + " es " + colores[x, y]);

                    puntosJugador1 += puntosJugador1;

                    Jugador1.text = "Puntos: " + puntosJugador1;
                    Jugador1_bonus.text = "Bonus: " + puntosJugador1 * bonus;
                    if (puntosJugador1 > puntosParaGanar)
                    {
                        //Ganador.gameObject.SetActive(true);

                        limiteDeJuego = true;
                        JugadorGanador1.gameObject.SetActive(limiteDeJuego);

                    }
                    //if (xEsferaAnterior > -1 && xEsferaAnterior < width - 1)
                    //    {

                    //        GameObject esferaAnterior = grid[xEsferaAnterior, yEsferaActual];
                    //        GameObject esfera3 = grid[xEsferaAnterior+2, yEsferaActual];

                    //        colorEsferaPrevia = esferaAnterior.GetComponent<Renderer>().material.color;
                    //        colorEsferaActual = esferaActual.GetComponent<Renderer>().material.color;
                    //        colorEsfera3 = esfera3.GetComponent<Renderer>().material.color;



                    //        esferaAnterior.GetComponent<Renderer>().material.color = comparadorDeColores.ColorAnterior(colorEsferaPrevia, colorEsferaActual,colorEsfera3);
                    //        esferaActual.GetComponent<Renderer>().material.color = comparadorDeColores.ColorActual(colorEsferaPrevia, colorEsferaActual,colorEsfera3);
                    //        esfera3.GetComponent<Renderer>().material.color = comparadorDeColores.ColorEsfera3(colorEsferaPrevia, colorEsferaActual,colorEsfera3);


                    //    }
                }
                else
                {
                    turno = 2;
                    UpdatePickedPiece(mPosition, turno);
                    GameObject esferaActual = grid[x, y];
                    int xEsferaAnterior = x - 1;
                    int yEsferaActual = y;
                    Debug.Log("El valor del color en " + " x = " + x + "y = " + y + " es " + colores[x, y]);

                    colores[x, y] = 2;
                    Debug.Log("El valor del color en " + " x = " + x + "y = " + y + " es " + colores[x, y]);
                    puntosJugador2 += puntosJugador2;

                    Jugador2.text = "Puntos: " + puntosJugador2;
                    Jugador2_bonus.text = "Bonus: " + puntosJugador2 * bonus;
                    if (puntosJugador2 > puntosParaGanar)
                    {
                        //Ganador.gameObject.SetActive(true);
                        limiteDeJuego = true;
                        JugadorGanador2.gameObject.SetActive(limiteDeJuego);

                    }
                    //if (xEsferaAnterior > -1 && xEsferaAnterior < width - 1)
                    //    {

                    //        GameObject esferaAnterior = grid[xEsferaAnterior, yEsferaActual];
                    //        GameObject esfera3 = grid[xEsferaAnterior+2, yEsferaActual];

                    //        colorEsferaPrevia = esferaAnterior.GetComponent<Renderer>().material.color;
                    //        colorEsferaActual = esferaActual.GetComponent<Renderer>().material.color;
                    //        colorEsfera3 = esfera3.GetComponent<Renderer>().material.color;



                    //        esferaAnterior.GetComponent<Renderer>().material.color = comparadorDeColores.ColorAnterior(colorEsferaPrevia, colorEsferaActual,colorEsfera3);
                    //        esferaActual.GetComponent<Renderer>().material.color = comparadorDeColores.ColorActual(colorEsferaPrevia, colorEsferaActual,colorEsfera3);
                    //        esfera3.GetComponent<Renderer>().material.color = comparadorDeColores.ColorEsfera3(colorEsferaPrevia, colorEsferaActual,colorEsfera3);

                    //    }
                }
                jugador = !jugador;
            }
        }


    }

    void UpdatePickedPiece(Vector3 position, int a)
    {

        int x = (int)(position.x + 0.5f);
        int y = (int)(position.y + 0.5f);

        if (a == 2)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                GameObject go = grid[x, y];

                go.GetComponent<Renderer>().material.SetColor("_Color", ColorJugador2());
                RecorridoDiagonalDerechaArriba(position);
                //RecorridoDiagonalDerechaAbajo();
                //RecorridoDiagonalIzquierdaArriba();
                //RecorridoDiagonalIzquierdaAbajo();
                //RecorridoArriba();
                //RecorridoAbajo();
                //RecorridoDerecha();
                //RecorridoIzquierda();



            }
        }
        else
            if (x >= 0 && y >= 0 && x < width && y < height)
        {
            GameObject go = grid[x, y];

            go.GetComponent<Renderer>().material.SetColor("_Color", ColorJugador1());
        }

    }
    public Color ColorJugador1()
    {
        Color jugador1 = Color.blue;
        return jugador1;

    }
    public Color ColorJugador2()
    {
        Color jugador2 = Color.red;
        return jugador2;

    }

    void RecorridoDiagonalDerechaArriba(Vector3 position)
        {
        int x = (int)(position.x + 0.5f);
        int y = (int)(position.y + 0.5f);
        Debug.Log("ganaste y la matriz es de: " + colores.Length);
        if (x < (colores.Length-2)&& y < (colores.Length - 2))
        {
            for(var a = 0; a < 4; a++)
            {
                if (colores[x,y]==colores[x+1,y+1])
                {
                    if (a == 4)
                    {
                        Debug.Log("ganaste y la matriz es de: " + colores.Length);
                    }
                    else
                    {
                        x += 1;
                        y += 1;
                    }
                }
            }
            
        }
        }
        


}

public class ComparadorDeColores
{

    public Color ColorActual(Color anterior, Color actual, Color esfera3)
    {

        Color colorVerificado = actual;
        Color colorDuplicado = Color.black;

            if (anterior == actual && esfera3 == actual)
            {

                colorVerificado = colorDuplicado;

            }

        return colorVerificado;

    }

    public Color ColorAnterior(Color anterior, Color actual, Color esfera3)
    {

        Color colorVerificado = anterior;
        Color colorDuplicado = Color.black;

            if (anterior == actual && esfera3 == anterior)
            {

                colorVerificado = colorDuplicado;

            }

        return colorVerificado;
    }
    public Color ColorEsfera3(Color anterior, Color actual, Color esfera3)
    {

        Color colorVerificado = esfera3;
        Color colorDuplicado = Color.black;

            if (anterior == esfera3 && esfera3 == actual)
            {

                colorVerificado = colorDuplicado;

            }

        return colorVerificado;
    }
}



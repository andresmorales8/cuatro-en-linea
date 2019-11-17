using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject puzzlePiece;
    private GameObject[,] grid;
    bool jugador = true;
    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[width, height];
        for (int x = 0; x<width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject go = GameObject.Instantiate(puzzlePiece) as GameObject;
                Vector3 position = new Vector3(x, y, 0);
                go.transform.position = position;
                grid[x,y]= go;
                
            }
        }
    }

    // Update is called once per frame 0= verde y 1 = rojo
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
        if (click)
        {
            int turno=0;
            if (jugador==true)
            {
                turno = 1;
                UpdatePickedPiece(mPosition, turno);
                GameObject esferaActual = grid[x, y];
                    int xEsferaAnterior = x - 1;
                    int yEsferaActual = y;

                    if (xEsferaAnterior > -1 && xEsferaAnterior < width - 1)
                    {

                        GameObject esferaAnterior = grid[xEsferaAnterior, yEsferaActual];
                        GameObject esfera3 = grid[xEsferaAnterior+2, yEsferaActual];

                        colorEsferaPrevia = esferaAnterior.GetComponent<Renderer>().material.color;
                        colorEsferaActual = esferaActual.GetComponent<Renderer>().material.color;
                        colorEsfera3 = esfera3.GetComponent<Renderer>().material.color;

                        

                        esferaAnterior.GetComponent<Renderer>().material.color = comparadorDeColores.ColorAnterior(colorEsferaPrevia, colorEsferaActual,colorEsfera3);
                        esferaActual.GetComponent<Renderer>().material.color = comparadorDeColores.ColorActual(colorEsferaPrevia, colorEsferaActual,colorEsfera3);
                        esfera3.GetComponent<Renderer>().material.color = comparadorDeColores.ColorEsfera3(colorEsferaPrevia, colorEsferaActual,colorEsfera3);


                    }
            }
            else
            {
                turno = 0;
                UpdatePickedPiece(mPosition, turno);
                GameObject esferaActual = grid[x, y];
                    int xEsferaAnterior = x - 1;
                    int yEsferaActual = y;

                    if (xEsferaAnterior > -1 && xEsferaAnterior < width - 1)
                    {

                        GameObject esferaAnterior = grid[xEsferaAnterior, yEsferaActual];
                        GameObject esfera3 = grid[xEsferaAnterior+2, yEsferaActual];

                        colorEsferaPrevia = esferaAnterior.GetComponent<Renderer>().material.color;
                        colorEsferaActual = esferaActual.GetComponent<Renderer>().material.color;
                        colorEsfera3 = esfera3.GetComponent<Renderer>().material.color;

                        

                        esferaAnterior.GetComponent<Renderer>().material.color = comparadorDeColores.ColorAnterior(colorEsferaPrevia, colorEsferaActual,colorEsfera3);
                        esferaActual.GetComponent<Renderer>().material.color = comparadorDeColores.ColorActual(colorEsferaPrevia, colorEsferaActual,colorEsfera3);
                        esfera3.GetComponent<Renderer>().material.color = comparadorDeColores.ColorEsfera3(colorEsferaPrevia, colorEsferaActual,colorEsfera3);

                    }
            }
            jugador=!jugador;
        }
        

    }

    void UpdatePickedPiece(Vector3 position, int a)
    {
        //Debug.Log(position.x + " - " + position.y);
        int x = (int)(position.x + 0.5f);
        int y = (int)(position.y + 0.5f);
        /*for(int _x = 0; _x < width; _x++)
        {
            for(int _y = 0; _y < height; _y++)
            {
                GameObject go = grid[_x, _y];
                go.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);

            }

        }*/
        if (a==0)
        {
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                GameObject go = grid[x, y];
                //Debug.Log(x+" - "+y);
                go.GetComponent<Renderer>().material.SetColor("_Color", ColorJugador2());
            }
        }
        else
            if (x >= 0 && y >= 0 && x < width && y < height)
        {
            GameObject go = grid[x, y];
            //Debug.Log(x+" - "+y);
            go.GetComponent<Renderer>().material.SetColor("_Color", ColorJugador1());
        }

    }
    public Color ColorJugador1()
    {
        Color jugador1 = Color.red;
        return jugador1;

    }
    public Color ColorJugador2()
    {
        Color jugador2 = Color.green;
        return jugador2;

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



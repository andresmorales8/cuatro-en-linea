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
    int bonus = 20;
    //public Text Ganador;
    public Text JugadorGanador1;
    public Text JugadorGanador2;
    public GameObject ReStart;

    int puntosParaGanar = 50;
    int puntosTotalesJugador1=0;
    int puntosTotalesJugador2=0;
    bool ganadorPorPuntos;
    int bonusJ1=0;
    int bonusJ2=0;
    bool limiteDeJuego;
    private int[,] colores = new int[10, 10];

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
        JugadorGanador1.gameObject.SetActive(limiteDeJuego);
        JugadorGanador2.gameObject.SetActive(limiteDeJuego);
        ReStart.gameObject.SetActive(limiteDeJuego);



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
                    limiteDeJuego = Comparador(mPosition);

                    
                    Jugador1.text = "Puntos: " + puntosJugador1;

                    if (ganadorPorPuntos)
                    {
                        bonusJ1 = puntosJugador1 + bonus; 
                    }
                    puntosTotalesJugador1 = puntosJugador1+bonusJ1;
                    Jugador1_bonus.text = "Bonus: " + puntosTotalesJugador1 +"Total: "+puntosTotalesJugador1;
                    
                    
                    puntosJugador1++;
                    
                    
                    if (limiteDeJuego || (puntosTotalesJugador1 > puntosParaGanar))
                    {
                        JugadorGanador1.gameObject.SetActive(limiteDeJuego);
                        ReStart.gameObject.SetActive(limiteDeJuego);


                    }
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
                    limiteDeJuego = Comparador(mPosition);

                    Jugador2.text = "Puntos: " + puntosJugador2;

                    if (ganadorPorPuntos)
                    {
                        bonusJ2 = puntosJugador2 + bonus;
                    }
                    puntosTotalesJugador2 = puntosJugador2+bonusJ2;
                    Jugador2_bonus.text = "Bonus: " + puntosTotalesJugador2;
                    
                    
                    puntosJugador2++;
                    
                    
                    if (limiteDeJuego || (puntosTotalesJugador2 > puntosParaGanar))
                    {

                        JugadorGanador2.gameObject.SetActive(limiteDeJuego);
                        ReStart.gameObject.SetActive(limiteDeJuego);


                    }
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
            if (x >= 0f && y >= 0f && x < width && y < height)
            {
                GameObject go = grid[x, y];

                go.GetComponent<Renderer>().material.SetColor("_Color", ColorJugador2());

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


    public bool Comparador(Vector3 position)
    {
        int x = (int)(position.x + 0.5f);
        int y = (int)(position.y + 0.5f);
        int filas = (colores.Length / width)-1 ;
        int columnas = (colores.Length / height)-1;
        int nEsferas = 2;
        bool esferasEnlinea = false;
        bool horizontal = Horizontal(x, y, filas, columnas, nEsferas);
        bool vertical = Vertical(x, y, filas, columnas, nEsferas);
        bool diagonalDerecha = DiagonalDerecha(x, y, filas, columnas, nEsferas);
        bool diagonalIzquierda = DiagonalIzquierda(x, y, filas, columnas, nEsferas);

            if(horizontal || vertical || diagonalDerecha || diagonalIzquierda){
                esferasEnlinea = true;
            }
        return esferasEnlinea;


    }
        
    public bool Horizontal(int x, int y, int filas, int columnas, int nEsferas)
    {
        bool esferasEnlinea = false;
            for (int i = 0; i < filas; i++)
            {
                int n = i+1; 
                if (((colores[i, y] != 0) || (colores[n, y] != 0)) && (n<filas+1))
                {

                    if (colores[i, y] == colores[i + 1, y])
                    {
                        Debug.Log("cumple "+ nEsferas +" esferasH" + filas);
                        
                        if (nEsferas==4)
                        {
                            esferasEnlinea = true;
                        }
                        else
                        if(nEsferas==3)
                        {
                            ganadorPorPuntos= true;

                        }
                        nEsferas++;
                    }
                    else
                    {
                        Debug.Log("No cumple esferasH" + filas);
                        nEsferas = 2;
                        ganadorPorPuntos= false;

                }

                }
            }
        return esferasEnlinea;
    }

    public bool Vertical(int x, int y, int filas, int columnas, int nEsferas)
    {
        bool esferasEnlinea = false;
            for (int i = 0; i < columnas; i++)
                {
                    int n = i + 1;
                    if (((colores[x, i] != 0) || (colores[x, n] != 0)) && (n < columnas+1))
                    {

                        if (colores[x, i] == colores[x, i + 1])
                        {
                            Debug.Log("cumple " + nEsferas + " esferasV" + filas);

                            if (nEsferas == 4)
                            {
                                esferasEnlinea = true;
                            }
                            else
                            if(nEsferas==3)
                            {
                                ganadorPorPuntos= true;

                            }
                            nEsferas++;
                        }
                        else
                        {
                            Debug.Log("No cumple esferasV" + filas);
                            nEsferas = 2;
                            ganadorPorPuntos= false;


                    }

                    }
                }
                return esferasEnlinea;
    }

    public bool DiagonalDerecha(int x, int y, int filas, int columnas, int nEsferas)
    {
        bool esferasEnlinea = false;
        
        int inicioLoopX=0; 
        int inicioLoopY=0;
        int limite=0; 

        if(x==y)
        {
            inicioLoopX=0;
            inicioLoopY=0;
            limite= CalculoDeLimite(inicioLoopX);
        }
        else
        if(x > y)
        {
            inicioLoopX=x-y;
            inicioLoopY=0;
            limite= CalculoDeLimite(inicioLoopX);

        }
        else
        if(y > x)
        {
            inicioLoopX=0; 
            inicioLoopY=y-x;
            limite= CalculoDeLimite(inicioLoopY);

        }
                for (int i = 0; i < limite; i++)
                {
                    
                    int c = inicioLoopX + 1;
                    int f = inicioLoopY + 1;
                    
                    if ((colores[inicioLoopX, inicioLoopY] == 0) || (colores[c, f] == 0)) 
                    {
                        nEsferas=2;
                    }
                    else 
                    if ((colores[inicioLoopX, inicioLoopY] != 0) || (colores[c, f] != 0)) 
                    {
                        
                        if (colores[inicioLoopX, inicioLoopY] == colores[c, f])
                        {
                            Debug.Log("cumple " + nEsferas + " esferas dD" + " f " + height +" c "+ width + " l"+limite+" c" + c + " f " + f +" loopX "+inicioLoopX+ " loopY "+inicioLoopY);

                            if (nEsferas == 4)
                            {
                                esferasEnlinea = true;
                            }
                            else
                            if(nEsferas==3)
                            {
                                ganadorPorPuntos= true;

                            }
                            nEsferas++;
                        }
                        else
                        {
                            Debug.Log("No cumple esferas dD" + " f " + height +" c "+ width + " l"+limite+ " c" + c + " f " + f +" loopX "+inicioLoopX+ " loopY "+inicioLoopY);
                            nEsferas = 2;
                            ganadorPorPuntos= false;

                        }
                    }
                        inicioLoopX = c;
                        inicioLoopY = f;
                        Debug.Log("iter "+c +"l"+limite);

                }
        return esferasEnlinea;
    }


    public bool DiagonalIzquierda(int x, int y, int filas, int columnas, int nEsferas)
    {
        bool esferasEnlinea = false;
        int inicioLoopX=0; 
        int inicioLoopY=0;
        int sumaVertices= x+y;
        int limite=0; 


        if(sumaVertices == filas)
        {
            inicioLoopX = 0;
            inicioLoopY = filas;
            limite= CalculoDeLimiteDI(inicioLoopY);
            
        }
        else
        if(sumaVertices < filas)
        {
            inicioLoopX=0;
            inicioLoopY = sumaVertices;
            limite= CalculoDeLimiteDI(inicioLoopY);

        }
        else
        if(sumaVertices > filas)
        {
            inicioLoopX = sumaVertices - filas;
            inicioLoopY = filas;
            limite= CalculoDeLimite(inicioLoopX);

        }
        
            for (int i = 0; i < limite; i++)
                {

                    int c = inicioLoopX + 1;
                    int f = inicioLoopY - 1;

                    if ((colores[inicioLoopX, inicioLoopY] == 0) || (colores[c, f] == 0)) 
                    {
                        nEsferas=2;
                    }
                    else 
                    if ((colores[inicioLoopX, inicioLoopY] != 0) || (colores[c, f] != 0)) 
                    {

                        if (colores[inicioLoopX, inicioLoopY] == colores[c, f])
                        {
                            Debug.Log("cumple " + nEsferas + " esferas dI" + " f " + height +" c "+ width + " l"+limite+ " c" + c + " f " + f +" loopX "+inicioLoopX+ " loopY "+inicioLoopY);

                            if (nEsferas == 4)
                            {
                                esferasEnlinea = true;
                            }
                            else
                            if(nEsferas==3)
                            {
                                ganadorPorPuntos= true;

                            }
                            nEsferas++;

                        }
                        else
                        {
                            Debug.Log("No cumple esferas dI"+ " f " + height +" c "+ width + " l"+limite+ " c" + c + " f " + f +" loopX "+inicioLoopX+ " loopY "+inicioLoopY);
                            nEsferas = 2;
                            ganadorPorPuntos= false;

                        }
                    }

                        inicioLoopX=c;
                        inicioLoopY=f;
                        Debug.Log("iter dI "+c +"l"+limite+" suma "+sumaVertices);

                }
        return esferasEnlinea;
    }

    public int CalculoDeLimite(int loop)
    {   
        int limite=1;
        switch (loop)
        {
            case 0:
                limite=9;
                break;
            case 1:
                limite=8;
                break;
            case 2:
                limite=7;
                break;
            case 3:
                limite=6;
                break;
            case 4:
                limite=5;
                break;
            case 5:
                limite=4;
                break;
            case 6:
                limite=3;
                break;
            case 7:
                limite=2;
                break;
            case 8:
                limite=1;
                break;
            case 9:
                limite=0;
                break;

        }


        return limite;
    }

        public int CalculoDeLimiteDI(int loop)
    {   
        int limite=1;
        switch (loop)
        {
            case 0:
                limite=0;
                break;
            case 1:
                limite=1;
                break;
            case 2:
                limite=2;
                break;
            case 3:
                limite=3;
                break;
            case 4:
                limite=4;
                break;
            case 5:
                limite=5;
                break;
            case 6:
                limite=6;
                break;
            case 7:
                limite=7;
                break;
            case 8:
                limite=8;
                break;
            case 9:
                limite=9;
                break;

        }


        return limite;
    }
}

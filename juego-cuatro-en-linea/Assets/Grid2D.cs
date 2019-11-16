using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid2D : MonoBehaviour
{
    public int width;
    public int height;
    public GameObject puzzlePiece;
    private GameObject[,] grid;
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
        bool jugador = true;


        if (click)
        {
            
            if (jugador==true)
            {
                int jugador1 = 1;
                UpdatePickedPiece(mPosition, jugador1);
                jugador = false;
            }
            else
            {
                int jugador2 = 0;
                UpdatePickedPiece(mPosition, jugador2);
                jugador = true;

            }

            
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

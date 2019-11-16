using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    public GameObject[] gos;
    // Start is called before the first frame update
    void Start()
    {
        gos = new GameObject[10];
        for (int i = 0; i < 10; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 v = new Vector3();
            v.x = Random.Range(-6, 6);
            v.z = Random.Range(-6, 6);
            go.transform.position = v;
            go.name = i.ToString();
            if (i%2==0)
            {
                go.AddComponent(typeof(ZombieData));
                go.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            }
            gos[i] = go;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

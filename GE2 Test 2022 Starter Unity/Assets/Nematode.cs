using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour
{
    public int length = 5;
    public Material material;


    void Awake()
    {
        length = UnityEngine.Random.Range(10, 25);
        for (int i = 0; i < length; i++)
        {             
            GameObject nemantode = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            nemantode.transform.position = new Vector3(0, 0, -i);
            float width = 1.5f - (i / (float)length);
            float height = 1.5f - (i / (float)length);
            nemantode.transform.localScale = new Vector3(width, height, 1);
            nemantode.transform.parent = this.transform;
            nemantode.GetComponent<Renderer>().material = material;
            nemantode.GetComponent<Renderer>().material.color = Color.HSVToRGB(i / (float)length, 1, 1);
        }
        GameObject onenematode = this.transform.GetChild(0).gameObject;
        onenematode.AddComponent<Boid>();
        onenematode.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Horizontal;
        onenematode.AddComponent<NoiseWander>().axis = NoiseWander.Axis.Vertical;
        onenematode.AddComponent<ObstacleAvoidance>();
        onenematode.AddComponent<Constrain>();
        


    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}

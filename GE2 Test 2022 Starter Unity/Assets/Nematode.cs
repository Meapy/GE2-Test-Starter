using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nematode : MonoBehaviour
{
    public int length = 5;
    public Material material;



    void Awake()
    {
        length = UnityEngine.Random.Range(25, 50);
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
        onenematode.AddComponent<Seek>();
    }


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(changeColor());
    }

    // Update is called once per frame
    void Update()
    {
        ///get the nematode to seek towards the health object
        GameObject targetHealth = GameObject.FindGameObjectWithTag("Health");
        if (targetHealth != null)
        {
            Seek seek = this.transform.GetChild(0).GetComponent<Seek>();
            seek.targetGameObject = targetHealth;
            this.transform.GetChild(0).GetComponent<NoiseWander>().enabled = false;
            GameObject[] healths = GameObject.FindGameObjectsWithTag("Health");
            foreach (GameObject health in healths)
            {
                if (Vector3.Distance(health.transform.position, this.transform.position) < 10)
                {
                    Destroy(health);
                    targetHealth = null;
                }
            }

        }

    }
    IEnumerator changeColor()
    {
        for (int i = 0; i < length; i++)
        {
            Color color = this.transform.GetChild(i).GetComponent<Renderer>().material.color;
            if (i > 0)
            {
                this.transform.GetChild(i - 1).GetComponent<Renderer>().material.color = color;
            }
            else
            {
                this.transform.GetChild(length - 1).GetComponent<Renderer>().material.color = color;
            }

        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(changeColor());

    }

}

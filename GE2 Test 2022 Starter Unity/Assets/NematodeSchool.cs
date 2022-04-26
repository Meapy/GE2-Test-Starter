using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NematodeSchool : MonoBehaviour
{
    public GameObject prefab;

    [Range (1, 5000)]
    public int radius = 50;
    
    public int count = 10;

    // Start is called before the first frame update
    void Awake()
    {
        //create the nematodes
        for (int i = 0; i < count; i++)
        {
            GameObject nematode = Instantiate(prefab, transform);
            nematode.transform.position = Random.insideUnitSphere * radius;
            nematode.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NematodeSchool : MonoBehaviour
{
    public GameObject prefab;

    [Range (1, 5000)]
    public int radius = 50;
    
    public int count = 10;
    public GameObject health;

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
        StartCoroutine(spawnHealth());

    }
    

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator spawnHealth()
    {
        yield return new WaitForSeconds(5f);
        //instantiate health
        GameObject health = GameObject.Instantiate(this.health);
        //set the position to spawn at random within the spawn radius
        Vector2 position = Random.insideUnitCircle * 20;
        //set the hight to be random 
        float height = Random.Range(0, 10);
        //set the position of the health
        health.transform.position = new Vector3(position.x, height, position.y);
        
        StartCoroutine(spawnHealth());
    }
}

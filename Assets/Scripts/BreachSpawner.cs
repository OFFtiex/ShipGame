using System;
using UnityEngine;

public class BreachSpawner : MonoBehaviour
{
    public GameObject BreachPrefab;
    public  int maxBreaches = 6;
    public float firstTimer = 30f;
    public float spawnDistance = 5f;

    private float timer;

    void Start()
    {
        timer = firstTimer;
    }

    void Update()
    {   

        timer -= Time.deltaTime;
        if (timer <= 0)
        {   
            timer = UnityEngine.Random.Range(5f, 20f);
            if (transform.childCount < maxBreaches)
            {
                Instantiate(BreachPrefab, UnityEngine.Random.insideUnitCircle * spawnDistance, Quaternion.identity, transform);
            } 
        }
    }

}

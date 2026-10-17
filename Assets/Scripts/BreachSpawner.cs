using System;
using UnityEngine;

public class BreachSpawner : MonoBehaviour
{
    public GameObject BreachPrefab;
    public float height; 
    public float width;
    public  int maxBreaches = 6;
    public float firstTimer = 30f;

    private float timer;

    void Start()
    {   
        height = transform.position.y;
        width = transform.position.x;
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
                Vector2 randPos = new Vector2(UnityEngine.Random.Range(width - 7.5f, width + 7.5f),
                                      UnityEngine.Random.Range(height - 0.5f, height + 0.5f));
                Instantiate(BreachPrefab, randPos, Quaternion.identity, transform);
            } 
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject blocks;
    public GameObject book;
    public GameObject coffee;
    public GameObject blast, glob;

    public GameObject[] philosophers;

    public Transform cat;
    
    private Queue<GameObject> block_list = new Queue<GameObject>();
    private Queue<GameObject> philo_list = new Queue<GameObject>();
    private Queue<GameObject> pickup_list = new Queue<GameObject>();

    public float maxPickupHeight = 50f;

    private float maxX = 0;

    public float maximumPlus = 350f;
    public float xPlus = 35f;
    
    public float philoOffsetX = 5.5f, philoOffsetY = -0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int maxObjects = 300;
    public int numBooks = 5, numCoffee = 5, numBlasts = 1, numGlobs = 1;

    // Update is called once per frame
    void Update()
    {
        float x = cat.position.x;

        while ((x + maximumPlus) > maxX)
        {
            maxX += xPlus;
            GameObject gameObject = Instantiate(blocks, new Vector3(maxX, 0, 0), Quaternion.identity);

            int rng = Random.Range(0, philosophers.Length);
            GameObject phil = Instantiate(philosophers[rng], new Vector3(maxX + philoOffsetX, philoOffsetY, 0), Quaternion.identity);
            

            if (block_list.Count >= 20)
            {
                GameObject toKill = block_list.Dequeue();
                Destroy(toKill);

                toKill = philo_list.Dequeue();
                Destroy(toKill);
            }

            block_list.Enqueue(gameObject);
            philo_list.Enqueue(phil);

            for(int i = 0; i< numBooks; i++)
            {
                float randX = Random.Range(0f, xPlus);
                float randY = Random.Range(0f, maxPickupHeight);

                GameObject b = Instantiate(book, new Vector3(maxX + randX, randY, 0), Quaternion.identity);
                pickup_list.Enqueue(b);
            }

            for (int i = 0; i < numCoffee; i++)
            {
                float randX = Random.Range(0f, xPlus);
                float randY = Random.Range(0f, maxPickupHeight);

                GameObject c = Instantiate(coffee, new Vector3(maxX + randX, randY, 0), Quaternion.identity);
                pickup_list.Enqueue(c);
            }


            for (int i = 0; i < numBlasts; i++)
            {
                float randX = Random.Range(0f, xPlus);
                float randY = Random.Range(0f, maxPickupHeight);

                GameObject c = Instantiate(blast, new Vector3(maxX + randX, randY, 0), Quaternion.identity);
                pickup_list.Enqueue(c);
            }
            
            for (int i = 0; i < numGlobs; i++)
            {
                float randX = Random.Range(0f, xPlus);
                float randY = Random.Range(0f, maxPickupHeight);

                GameObject c = Instantiate(glob, new Vector3(maxX + randX, randY, 0), Quaternion.identity);
                pickup_list.Enqueue(c);
            }

            while (pickup_list.Count > maxObjects)
            {
                GameObject tokill = pickup_list.Dequeue();
                Destroy(tokill);
            }

        }

    }
}

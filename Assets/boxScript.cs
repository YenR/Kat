using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("box collided");
        if (collision.gameObject.tag == "cat")
        {
            Debug.Log("cat collided with blocks");
            catScript.instance.crashOntoFloor();
        }
    }
}

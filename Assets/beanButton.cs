using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanButton : MonoBehaviour
{
    public Rigidbody beanRigidbody;

    public float forceValx = 1f;
    public float forceValy = 0.5f;

    public void pressButton()
    {
        Debug.Log("button pressed!");

        beanRigidbody.AddForce(forceValx, forceValy, 0, ForceMode.Impulse);

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

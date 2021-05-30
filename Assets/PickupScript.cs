using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public string type;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coffee");
        if(collision.gameObject.tag == "cat")
        {
            Debug.Log("cat coffee");
        }
    }

}

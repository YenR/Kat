using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform cam;
    public Transform bean;

    public float smoothSpeed = 10f;

    public Vector3 camOffset;

    public float beanYthreshold = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition;

        if(bean.position.y > beanYthreshold)
        {
            desiredPosition = new Vector3(bean.position.x, bean.position.y, cam.position.z) + camOffset;
        }
        else
            desiredPosition = new Vector3(bean.position.x, 0, cam.position.z) + camOffset;

        cam.position = Vector3.Lerp(cam.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        //cam.LookAt(bean);
    }
}

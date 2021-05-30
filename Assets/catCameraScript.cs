using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catCameraScript : MonoBehaviour
{
    public Transform cam;
    public Transform cat;

    public float smoothSpeed = 10f;
    public Vector3 camOffset = new Vector3(10, -1, -10);
    public float catYthreshold = 10f;

    public float blendLevel = 0f, blendChange = 0f;
    public float blendYthreshold = 10f;
    public void blendSkybox()
    {
        if (blendChange != 0f)
            blendChange *= -1;
        else if (blendLevel == 0f)
            blendChange = 0.01f;
        else
            blendChange = -0.01f;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition;

        if (cat.position.y > catYthreshold)
        {
            desiredPosition = new Vector3(cat.position.x, cat.position.y, 0) + camOffset;
        }
        else
        {
            desiredPosition = new Vector3(cat.position.x, 0, 0) + camOffset;
        }

        if (cat.position.y > blendYthreshold && blendChange < 0.01f)
            blendSkybox();
        else if (cat.position.y < blendYthreshold && blendChange > -0.01f)
            blendSkybox();

        cam.position = Vector3.Lerp(cam.position, desiredPosition, smoothSpeed * Time.deltaTime);
        
        if (blendChange != 0f)
        {
            blendLevel += blendChange;
            RenderSettings.skybox.SetFloat("_Blend", blendLevel);
            if (blendLevel >= 1f)
            {
                blendLevel = 1f;
                blendChange = 0f;
            }
            if (blendLevel <= 0f)
            {
                blendLevel = 0f;
                blendChange = 0f;
            }
        }
    }
}

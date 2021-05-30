using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class quoteScript : MonoBehaviour
{
    public float alpha = 1f;
    public UnityEngine.UI.Image image;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(alpha > 0f)
        {
            alpha -= Time.deltaTime/2;
            var tmpColor = image.color;
            tmpColor.a = alpha;
            image.color = tmpColor;
            text.color = tmpColor;
        }
        if (alpha <= 0f)
            Destroy(this.gameObject);
    }
}

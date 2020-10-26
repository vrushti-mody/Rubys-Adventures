using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    
    void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Screen.width / Screen.height;

        if (gameObject.name == "Background") {
            transform.localScale = new Vector3(width, height, 0);
        } else {
            transform.localScale = new Vector3(width + 3f, 5, 0);
        }
    }

}

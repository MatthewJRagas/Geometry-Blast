using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 boundaryCheck = cam.WorldToViewportPoint(transform.position);
        if(boundaryCheck.x < 0 || boundaryCheck.x > 1)
        {
            Destroy(gameObject);
        }
        else if(boundaryCheck.y < 0 || boundaryCheck.y > 1)
        {
            Destroy(gameObject);
        }
        else
        {

        }
    }
}

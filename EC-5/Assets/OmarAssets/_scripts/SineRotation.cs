using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineRotation : MonoBehaviour
{

    public float z_radious;
    public float DegXFrme;



    private float angle = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float z_rot = z_radious * Mathf.Sin(angle);

        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, z_rot));
        angle += Mathf.Deg2Rad * DegXFrme;
    }
}

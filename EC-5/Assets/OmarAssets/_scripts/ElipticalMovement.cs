using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElipticalMovement : MonoBehaviour {

    public Transform anchor;
    public float x_radious;
	public float y_radious;
	public float DegXFrme;



	private float angle = 0;


	
	
	// Update is called once per frame
	void Update () {
		float x_pos = x_radious * Mathf.Cos (angle);
		float y_pos = y_radious * Mathf.Sin (angle);

        transform.position = new Vector3(x_pos, y_pos, 0f) + anchor.position;
		angle += Mathf.Deg2Rad * DegXFrme;


	}


}

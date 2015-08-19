using UnityEngine;
using System.Collections;

public class DollyZoom : MonoBehaviour {

	public Transform target;
	
	public Camera cam;
	public float distance=0f;
	public float fov = 60;
	
	public float viewWidth = 10f; 
	
	void Start () {
		cam = Camera.main;
	}
	
	void Update () 
	{
		Vector3 pos = cam.transform.position;
		
		fov = cam.fieldOfView;
		distance = viewWidth / ( 2f*Mathf.Tan(0.5f*fov*Mathf.Deg2Rad) );
		
		pos.z = -Mathf.Abs(distance);
		cam.transform.position = pos;
	}
}

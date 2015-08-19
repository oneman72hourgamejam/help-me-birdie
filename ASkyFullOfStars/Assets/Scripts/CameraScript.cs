using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float speed = 1.0f;
    public float acceleration = 0.1f;
    public float maxSpeed = 6f;
    public float smooth = 0.1f;

	public float easySpeed = 2f;
	public float mediumSpeed = 4f;
	public float hardSpeed = 6f;

	public bool moveCamera;

    public int targetWidth = 640;
//    public int targetHeight = 800;

	//[SerializeField]
	//private GameObject speedText;

    public float pixelToUnits = 100.0f;
	// Use this for initialization
	void Start () {
		moveCamera = true;
        ScaleByWidth ();
		speed = 1.0f;
//		speedText.guiText.text = "" + speed;
	}

	// Update is called once per frame
	void Update () {
		if(moveCamera){
	   		MoveCamera ();
		}
	}

	public void SetEasySpeed(){
		this.maxSpeed = easySpeed;
	}

	public void SetMediumSpeed(){
		this.maxSpeed = mediumSpeed;
	}

	public void SetHardSpeed () {
		this.maxSpeed = hardSpeed;
	}

    void MoveCameraByLerp() {

        Vector3 temp = transform.position;

        temp.y = Mathf.Lerp (temp.y, temp.y - (speed * Time.deltaTime), smooth);

        transform.position = temp;

        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
            speed = maxSpeed;
    }

    void MoveCamera() {

        Vector3 temp = transform.position;

        float oldY = temp.y;

        float newY = temp.y - (speed * Time.deltaTime);

        temp.y = Mathf.Clamp (temp.y, oldY, newY);

        transform.position = temp;

        speed += acceleration * Time.deltaTime;

        if (speed > maxSpeed)
                speed = maxSpeed;

    }
    void ScaleByWidth() {

        int height = Mathf.CeilToInt (targetWidth / (float)Screen.width * Screen.height);

        camera.orthographicSize = height / pixelToUnits / 2;

        if (camera.orthographicSize < 3.6)
                        camera.orthographicSize = 3.6f;

    }
}

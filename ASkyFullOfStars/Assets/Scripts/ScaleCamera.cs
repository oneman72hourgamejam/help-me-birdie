using UnityEngine;
using System.Collections;

public class ScaleCamera : MonoBehaviour {

    public int targetWidth = 480;
//    public int targetHeight = 800;

    public float pixelToUnits = 100.0f;

	// Use this for initialization
	void Start () {
        ScaleByWidth ();
	}

	// Update is called once per frame
	void Update () {

	}

    void ScaleByPixelDensity (){
        Camera.main.orthographicSize = Screen.height / pixelToUnits / 2;
    }

    void ScaleByWidth() {

        int height = Mathf.CeilToInt (targetWidth / (float)Screen.width * Screen.height);

        camera.orthographicSize = height / pixelToUnits / 2;

        //if (camera.orthographicSize < 3.6)
        //                camera.orthographicSize = 3.6f;

    }
}

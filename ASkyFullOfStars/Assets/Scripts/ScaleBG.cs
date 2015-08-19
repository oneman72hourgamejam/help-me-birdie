using UnityEngine;
using System.Collections;

public class ScaleBG : MonoBehaviour {

	// Use this for initialization
	void Start () {
	   SpriteRenderer sr = GetComponent<SpriteRenderer>();

       float spriteWidth = sr.sprite.bounds.size.x;
       float spriteHeight = sr.sprite.bounds.size.y;

       float worldScreenHeight = Camera.main.orthographicSize * 2.0f;
       float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

       Vector3 temp = transform.localScale;

       temp.x = worldScreenWidth / spriteWidth;
       temp.y = worldScreenHeight / spriteHeight;

       transform.localScale = temp;

	}

	// Update is called once per frame
	void Update () {

	}
}

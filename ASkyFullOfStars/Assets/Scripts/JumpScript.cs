using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {
	public float jumpSpeed = 200f;
	private Animator animator;
	public AudioClip jumpClip; 
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		var vel = rigidbody2D.velocity;
		if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
		{
			rigidbody2D.velocity = new Vector2 (vel.x, jumpSpeed);
			AudioSource.PlayClipAtPoint(jumpClip, transform.position);
			animator.SetInteger("Walk", 0);
		}

	}
}








































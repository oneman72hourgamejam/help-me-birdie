using UnityEngine;
using System.Collections;

public class ControllBackBtn : MonoBehaviour {
	public GameObject btn;
	public Animator animator;
	// Use this for initialization
	void Start () {
		animator = btn.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

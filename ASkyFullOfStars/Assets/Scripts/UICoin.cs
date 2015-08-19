using UnityEngine;
using System.Collections;
[ExecuteInEditMode]

public class UICoin : MonoBehaviour {

    public float x, y;

    // Use this for initialization
    void Start () {
       transform.position = Camera.main.ViewportToWorldPoint(new Vector3 (x, y, 5));
    }

    // Update is called once per frame
    void Update () {
       transform.position = Camera.main.ViewportToWorldPoint(new Vector3 (x, y, 5));
    }
}

using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour {
    private float height;
	// Use this for initialization
	void Start () {
        height = Random.Range(10, 20);
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localScale.y < height)
        {
            transform.localScale = new Vector3(
                transform.localScale.x,
                transform.localScale.y + 0.5f,
                transform.localScale.z);
        }
	}
}

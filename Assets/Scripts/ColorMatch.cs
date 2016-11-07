using UnityEngine;
using System.Collections;

public class ColorMatch : MonoBehaviour {
    
    void OnTriggerEnter(Collider collision)
    {
        var gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        if (collision.gameObject.tag == "Player" &&
            this.GetComponent<Renderer>().material.color
            != collision.gameObject.GetComponent<Renderer>().material.color)
        {
            Destroy(gameObject);
            gm.isCollided = true;         
        }
        else
        {
            gm.isAlive = false;            
        }
    }    
}

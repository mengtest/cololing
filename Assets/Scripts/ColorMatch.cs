using UnityEngine;
using System.Collections;

public class ColorMatch : MonoBehaviour {
    
    void OnTriggerEnter(Collider collision)
    {
        var gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        if (collision.gameObject.tag == "Player" &&
            this.GetComponent<MeshRenderer>().material.color
            != collision.gameObject.GetComponent<MeshRenderer>().material.color)
        {
            Destroy(gameObject);
            gm.isCollided = true;
            gm.score++;           
        }
        else
        {
            gm.isAlive = false;            
        }
    }    
}

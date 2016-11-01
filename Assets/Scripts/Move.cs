using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
    private Rigidbody m_RigidBody;
    private int way_state;
    public float max_velocity;
    private bool uniform;

    // Use this for initialization
    void Start () {
        way_state = 1;
        m_RigidBody = GetComponent<Rigidbody>();
        uniform = false;
    }

	// Update is called once per frame
	void Update () {
        if (m_RigidBody.velocity.x >= max_velocity)
        {
            uniform = true;
        }
        if (!uniform)
        {
            m_RigidBody.AddForce(Vector3.right * 500 * Time.deltaTime);
            m_RigidBody.AddTorque(Vector3.back * 500 * Time.deltaTime);
        }
        Debug.Log(m_RigidBody.velocity);
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        switch (way_state)
        {
            case 1:
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    transform.transform.position = new Vector3(transform.position.x, transform.position.y, 4f);
                    way_state = 2;
                    yield return new WaitForSeconds(1);
                }
                break;
            case 2:
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    transform.transform.position = new Vector3(transform.position.x, transform.position.y, -4f);
                    way_state = 3;
                    yield return new WaitForSeconds(1);
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    transform.transform.position = new Vector3(transform.position.x, transform.position.y, 12f);
                    way_state = 1;
                    yield return new WaitForSeconds(1);
                }
                break;
            case 3:
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    transform.transform.position = new Vector3(transform.position.x, transform.position.y, -12f);
                    way_state = 4;
                    yield return new WaitForSeconds(1);
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    transform.transform.position = new Vector3(transform.position.x, transform.position.y, 4f);
                    way_state = 2;
                    yield return new WaitForSeconds(1);
                }
                break;
            case 4:
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    transform.transform.position = new Vector3(transform.position.x, transform.position.y, -4f);
                    way_state = 3;
                    yield return new WaitForSeconds(1);
                }
                break;
        }
    }
}

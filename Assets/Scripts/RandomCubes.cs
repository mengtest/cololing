using UnityEngine;
using System.Collections;

public class RandomCubes : MonoBehaviour {
    public GameObject spawn;
    public Color[] colors = { Color.blue, Color.red, Color.yellow };
    private GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(spawner());
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator spawner()
    {
        yield return new WaitForSeconds(2);
        while (player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            var player_position = player.transform.position;
            var spawn_rotation = Quaternion.identity;
            float[] state = { -12f, -4f, 4f, 12f };
            GameObject[] cubes = new GameObject[state.Length];
            var player_color = player.GetComponent<MeshRenderer>().material.color;
            for(int i = 0; i < state.Length; i++)
            {
                var spawn_position = new Vector3(
                    Random.Range(player_position.x + 30, player_position.x + 60),
                    player_position.y,
                    state[i]
                    );
                var cube = Instantiate(spawn, spawn_position, spawn_rotation) as GameObject;
                cubes[i] = cube;
                //cube.GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length)];
            }
            var chosen_index = Random.Range(0, state.Length-1);
            var chosen_color = colors[Random.Range(0, colors.Length - 1)];
            while (chosen_color == player_color)
            {
                chosen_color = colors[Random.Range(0, colors.Length - 1)];
            }
            cubes[chosen_index].GetComponent<MeshRenderer>().material.color = chosen_color;
            for (int i = 0; i < state.Length; i++)
            {
                if (i != chosen_index)
                {
                    cubes[i].GetComponent<MeshRenderer>().material.color = player_color;
                }
            }
            //for (int i = 0; i < state.Length; i++)
            //{
            //    Debug.Log(cubes[i].GetComponent<MeshRenderer>().material.color);
            //}
            yield return new WaitForSeconds(4);
        }
    }
}

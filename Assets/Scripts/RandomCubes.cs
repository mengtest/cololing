using UnityEngine;
using System.Collections;

public class RandomCubes : MonoBehaviour {
    public GameObject spawn;
    private GameObject player;
    private GameManager gm;
    private Renderer rend;
    private Shader standard_shader;
    // Use this for initialization
    void Start() {
        rend = GetComponent<Renderer>();
        standard_shader = Shader.Find("Standard");
        rend.material.shader = standard_shader;
        player = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        StartCoroutine(spawner());
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(rend.material.GetColor("_Color"));
    }

    IEnumerator spawner()
    {
        while (player)
        {
            var velocity = GetComponent<Rigidbody>().velocity.x;
            player = GameObject.FindGameObjectWithTag("Player");
            var player_position = player.transform.position;
            var spawn_rotation = Quaternion.identity;
            float[] state = { -12f, -4f, 4f, 12f };
            GameObject[] cubes = new GameObject[state.Length];
            var player_color = rend.material.color;

            for (int i = 0; i < state.Length; i++)
            {
                var spawn_position = new Vector3(
                    Random.Range(player_position.x + 30 + .8f * velocity, player_position.x + 60 + .8f * velocity),
                    player_position.y,
                    state[i]
                    );
                if (spawn_position.x > gm.upper_bound)
                {
                    gm.upper_bound = spawn_position.x;
                }
                if (spawn_position.x < gm.lower_bound)
                {
                    gm.lower_bound = spawn_position.x;
                }
                var cube = Instantiate(spawn, spawn_position, spawn_rotation) as GameObject;
                cube.GetComponent<Renderer>().material.shader = standard_shader;
                cubes[i] = cube;
            }

            var chosen_index = Random.Range(0, state.Length - 1);


            for (int i = 0; i < state.Length; i++)
            {
                if (i != chosen_index)
                {
                    cubes[i].GetComponent<Renderer>().material.color = player_color;
                }
            }
            var chosen_color = new Color(player_color.r + 0.1f, player_color.g + 0.1f, player_color.b + 0.1f);
            cubes[chosen_index].GetComponent<Renderer>().material.color = chosen_color;
            
            yield return new WaitForSeconds(4);
        }
    }
}

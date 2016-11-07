using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int score;
    public Text score_board;
    public GameObject game_over;
    public GameObject game_win;
    public Button restart;
    public Button exit;
    public Button win_restart;
    public bool isAlive;
    public bool isCollided;
    public bool isWinner;
    public float upper_bound;
    public float lower_bound;
    public float final_bound;
    private Button.ButtonClickedEvent event_restart;
    private Button.ButtonClickedEvent event_continue;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        event_restart = new Button.ButtonClickedEvent();
        event_restart.AddListener(Restart);
        restart.onClick = event_restart;
        win_restart.onClick = event_restart;
        event_continue = new Button.ButtonClickedEvent();
        event_continue.AddListener(Continue);
    }
	
	// Update is called once per frame
	void Update () {
        if (!isAlive || isWinner)
        {
            var cubes = GameObject.FindGameObjectsWithTag("Respawn");
            foreach (var item in cubes)
            {
                Destroy(item);
            }
            Destroy(player);
        }
        if (!isAlive)
        {         
            game_over.SetActive(true); 
        }
        if (isWinner)
        {
          game_win.SetActive(true);
        }
    }

    void Continue()
    {
        if(score >= 10)
        {
            game_over.SetActive(false);
            score -= 10;
        }
        else
        {

        }
    }

    void Restart()
    {
        SceneManager.LoadScene("Scene");
    }
}

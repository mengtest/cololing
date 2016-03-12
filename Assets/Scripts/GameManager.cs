using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int score;
    public Text score_board;
    public GameObject game_over;
    public Button restart;
    public Button exit;
    public bool isAlive;
    public bool isCollided;
    private Button.ButtonClickedEvent event_restart;
    private Button.ButtonClickedEvent event_continue;
	// Use this for initialization
	void Start () {
        score = 0;
        isAlive = true;
        event_restart = new Button.ButtonClickedEvent();
        event_restart.AddListener(Restart);
        restart.onClick = event_restart;
        event_continue = new Button.ButtonClickedEvent();
        event_continue.AddListener(Continue);
        
    }
	
	// Update is called once per frame
	void Update () {
        score_board.text = "Color: " + score;
        if (!isAlive)
        {
            var cubes = GameObject.FindGameObjectsWithTag("Respawn");
            foreach (var item in cubes){
                Destroy(item);
            }
            game_over.SetActive(true); 
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

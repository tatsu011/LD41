using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchOfTheDay : MonoBehaviour {

    public string CaughtFish;
    public int FinalScore
    {
        get;
        private set;
    }

    public static CatchOfTheDay Instance
    {
        get;
        private set;
    }


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        Instance = this;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FinalScore = ScoreObject.GetScore();
            FinalScore += collision.gameObject.GetComponent<PlayerController>().HeldScore;
            gameObject.SetActive(false);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            SceneManager.LoadScene("FinalCatch");
            
        }
    }
}

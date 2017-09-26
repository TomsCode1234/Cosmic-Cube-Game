using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropManager : MonoBehaviour {

    public float fallSpeed = 4.0f;
    public int Score = 0;
    public int IncScore = 1;
    public int CurCol = 0;
    public float MoveSpeed = 8.0f;

    public GameObject Menu;
    public GameObject RightUI;
    public GameObject LeftUI;
    public GameObject EndUI;
    public GameObject Drop;
    public Transform[] spawnPoints;
    public GameObject main;
    public AudioClip DeathSound;
    public AudioClip ScoreSound;

    Animator anim;
    Animator RightAnim;
    Animator LeftAnim;
    Animator EndAnim;

    AudioSource CubeColSound;

    public GameObject PlayObj;
    Animator cubeanim;
    private object gameobject;
    public Text endscore;
    public Text Highscoretxt;
    int highscore;

    GameObject ChangeMat;

    void Awake()
    {
        anim = Menu.GetComponent<Animator>();
        cubeanim = PlayObj.GetComponent<Animator>();
        RightAnim = RightUI.GetComponent<Animator>();
        LeftAnim = LeftUI.GetComponent<Animator>();
        EndAnim = EndUI.GetComponent<Animator>();
        CubeColSound = GameObject.Find("HitCube").GetComponent<AudioSource>();
        ChangeMat = GameObject.Find("HitCube");
    }

    public void ScorePoint()
    {
        CubeColSound.clip = ScoreSound;
        CubeColSound.Play();
    }

    public void MissPoint()
    {
        CubeColSound.clip = DeathSound;
        CubeColSound.Play();
    }

	public void StartGame ()
    {
        Debug.Log("Start Button Clicked");

        ChangeMat.GetComponent<ChangeMat>().playSound();

        anim.SetTrigger("Started");
        cubeanim.SetBool("IsGame", true);
        RightAnim.SetBool("IsGame", true);
        LeftAnim.SetBool("IsGame", true);
        spawn();
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        cubeanim.SetBool("IsGame", false);
        RightAnim.SetBool("IsGame", false);
        LeftAnim.SetBool("IsGame", false);
        EndAnim.SetBool("IsGameOver", true);
        endscore.text = ("Score: " + Score.ToString());

        highscore = PlayerPrefs.GetInt ("highscore", highscore);

        if (Score > highscore)
        {
            highscore = Score;

            PlayerPrefs.SetInt("highscore", highscore);
        }
        string HS = (highscore.ToString());
        Debug.Log(HS);
        Highscoretxt.text = ("High Score: " + HS);
    }

    public void RestartGame()
    {
        EndAnim.SetBool("IsGameOver", false);
        cubeanim.SetBool("IsGame", true);
        RightAnim.SetBool("IsGame", true);
        LeftAnim.SetBool("IsGame", true);

        Score = 0;
        IncScore = 1;
        fallSpeed = 3.0f;

        spawn();
    }

    public void spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        (Instantiate(Drop, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation)).transform.parent = main.transform;
    }
}

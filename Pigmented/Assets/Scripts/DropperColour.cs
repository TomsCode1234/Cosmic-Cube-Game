using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropperColour : MonoBehaviour {

    public float spinspeed = 250.0f;
    public float IncSpeed = 0.2f;
    public int IncDiff = 1;

    GameObject DropManager;
    GameObject HitBox;
    Text txtscr;
    

	void Start () {
        DropManager = GameObject.Find("Game Manager");
        txtscr = GameObject.Find("Main UI").GetComponentInChildren<Text>();
        HitBox = GameObject.Find("HitCube");
        SetRanCol();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.down * DropManager.GetComponent<DropManager>().fallSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, spinspeed * Time.deltaTime);
    }
	
	void SetRanCol()
    {
        var randomInt = Random.Range(1, 5);
        Debug.Log(randomInt);
        while (randomInt == DropManager.GetComponent<DropManager>().CurCol)
        {
            randomInt = Random.Range(1, 5);
        }
            if(randomInt == 1)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            if (randomInt == 2)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
            if (randomInt == 3)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (randomInt == 4)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }

        DropManager.GetComponent<DropManager>().CurCol = randomInt;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == HitBox)
        {
            if ((gameObject.GetComponent<Renderer>().material.color) == (HitBox.GetComponent<Renderer>().material.color))
            {
                Debug.Log("positive Hit");
                DropManager.GetComponent<DropManager>().Score = (DropManager.GetComponent<DropManager>().Score + 1);
                txtscr.text = "Score: " + (DropManager.GetComponent<DropManager>().Score.ToString());
                DropManager.GetComponent<DropManager>().ScorePoint();

                if (DropManager.GetComponent<DropManager>().Score >= DropManager.GetComponent<DropManager>().IncScore)
                {
                    DropManager.GetComponent<DropManager>().fallSpeed = (DropManager.GetComponent<DropManager>().fallSpeed + IncSpeed);
                    DropManager.GetComponent<DropManager>().IncScore = DropManager.GetComponent<DropManager>().IncScore + IncDiff;
                }

                DropManager.GetComponent<DropManager>().spawn();

                this.gameObject.SetActive(false);
            }
            else
            {
                DropManager.GetComponent<DropManager>().MissPoint();
                DropManager.GetComponent<DropManager>().EndGame();

                this.gameObject.SetActive(false);
                //call end game function and ui
            }
        }
    }
}

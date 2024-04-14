using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public GameFlow Game_Flow;

    private string Lane_Change = "n";
    private string Jumping = "n";
    public static Vector3 Player_Position;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
    }

    void Update()
    {
        Player_Position = transform.position;
        if (Input.GetKeyDown("a") && Lane_Change == "n" && transform.position.x > -0.9 && Jumping == "n")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-2, 0, 4);
            Lane_Change = "y";
            StartCoroutine(Stop_Lane_Change());
        }
        if (Input.GetKeyDown("d") && Lane_Change == "n" && transform.position.x < 0.5 && Jumping == "n")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 4);
            Lane_Change = "y";
            StartCoroutine(Stop_Lane_Change());
        }
        if (Input.GetKeyDown("space") && Jumping == "n" && Lane_Change == "n")
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 4);
            Jumping = "y";
            StartCoroutine(Stop_Jumping());
        }

        //if (transform.position.y < -5f)
        //{
        //    Game_Flow.EndGame();
        //    Debug.Log("Конец игры");
        //}
    }
    IEnumerator Stop_Lane_Change()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
        Lane_Change = "n";
    }
    IEnumerator Stop_Jumping()
    {
        yield return new WaitForSeconds(.4f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, -5, 4);
        yield return new WaitForSeconds(.4f);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 4);
        Jumping = "n";
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Game_Flow.EndGame();
            Debug.Log("Конец игры!");
        }
    }
}

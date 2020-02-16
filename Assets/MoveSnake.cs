using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MoveSnake : MonoBehaviour
{
    public float speed;
    public GameObject body;
    public Vector2 direction;
    public Text textUI;

    private bool flag;
    private List<Transform> posTailTrans = new List<Transform>();
    private Vector2 tempPos;
    private GameObject child;
    private int score = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        flag = false;
        var temp = collision.collider.tag;
        switch (temp)
        {
            case "vertical":
                var i = transform.rotation.eulerAngles.z;
                transform.rotation = Quaternion.Euler(0, 0, -i);
                break;
            case "up":
                transform.rotation = Quaternion.Euler(0, 0, -180);
                break;
            case "down":
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case "food":
                score++;
                flag = true;
                break;
        }
        textUI.text = "Score" + " " + score.ToString();
    }
    void Start()
    {
        InvokeRepeating("Move", 0, 0.12f);
        
        //EatFood();

    }

    private void Move()
    {
        tempPos = transform.position;
        transform.Translate(direction);
        if (Input.GetKey(KeyCode.W) && transform.rotation.eulerAngles.z != 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey(KeyCode.S) && transform.rotation.eulerAngles.z != -180)
            transform.rotation = Quaternion.Euler(0, 0, -180);
        if (Input.GetKey(KeyCode.A) && transform.rotation.eulerAngles.z != 90)
            transform.rotation = Quaternion.Euler(0, 0, 90);
        if (Input.GetKey(KeyCode.D) && transform.rotation.eulerAngles.z != -90)
            transform.rotation = Quaternion.Euler(0, 0, -90);

        if (flag == true)
        {
            GameObject tail = Instantiate(body, tempPos, Quaternion.identity);
            posTailTrans.Insert(0, tail.transform);
            flag = false;


        }
        else if (posTailTrans.Count > 0)
        {
            posTailTrans.Last().position = tempPos;
            posTailTrans.Insert(0, posTailTrans.Last());
            posTailTrans.RemoveAt(posTailTrans.Count - 1);
        }
    }
}
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player_Movement : MonoBehaviour
{

    public float speed = 4;
    private int scoreVal = 0;
    public TextMeshProUGUI scoreBox;
    void Update() 
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
           transform.Translate(transform.up * speed * Time.deltaTime); 
        }

        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
           transform.Translate(-transform.up * speed * Time.deltaTime); 
        }       

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Rat" || collision.gameObject.tag == "Fireball" || collision.gameObject.tag == "HugeRat")
        {
            if(collision.GetComponent<Rat_Move>() != null)
            {
                scoreVal += collision.GetComponent<Rat_Move>().points;
                scoreBox.text = "Score: " + scoreVal;
            }
            Destroy(collision.gameObject);

        }
    }


}
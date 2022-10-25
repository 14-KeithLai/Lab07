using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rigid;
    public float velocity = 2.4f;
    int i = 0;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("fly");
            thisAnimation.Play();
            rigid.velocity = Vector2.up * velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="test")
        {
            i++;
            GameManager.thisManager.UpdateScore(i);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "walls")
        {
            SceneManager.LoadScene("gameover");
        }
        if (collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("gameover");
        }
    }
}

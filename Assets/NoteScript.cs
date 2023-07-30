using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool noteActive = true;
    public bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        rigidbody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        //if (Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
            rigidbody.gravityScale = 6;
            if(noteActive && started) {
                rigidbody.velocity = Vector2.up * flapStrength;
            }
        }

        if(rigidbody.position.y < -25)
        {
            logic.gameOver();
            noteActive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        noteActive = false;
    }
}

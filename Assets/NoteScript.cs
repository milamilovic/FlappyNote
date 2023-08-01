using System.Threading;
using UnityEngine;
using UnityEngine.Audio;

public class NoteScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool noteActive = true;
    public bool started = false;
    public AudioMixer mixerWithChuck;
    private string myChuck1;
    Thread updatingThread;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        rigidbody.gravityScale = 0;
        myChuck1 = "my_chuck";
        Chuck.Manager.Initialize(mixerWithChuck, myChuck1);
        Debug.Log("usao");
        Chuck.Manager.RunCode(myChuck1,
            @"
            SinOsc foo => dac;
            while( true )
            {
                Math.random2f( 300, 1000 ) => foo.freq;
                100::ms => now;
            }
        "
        );
        
    }

    private void OnApplicationQuit()
    {
        Chuck.Manager.Quit();
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

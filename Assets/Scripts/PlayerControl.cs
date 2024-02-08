using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float maxX;
    public float spawnX;
    public float xSpeed;
    public float ySpeed;
    public float xAccel;
    float currentXAccel = 0;
    public GameObject boing;
    public GameObject shotgun;
    public GameObject coin;
    public GameObject commentary;
    bool keysMode = false;
    int prevTouchCount = 0;
    bool touch = false;

    // Use this for initialization
    void Start()
    {

    }
    

    void OnCollisionEnter2D(Collision2D col)
    {
        playSound(shotgun);
        currentXAccel = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playSound(coin);
    }

    void speedUpdate()
    {
        float vx = transform.GetComponent<Rigidbody2D>().velocity.x;
        float vy = transform.GetComponent<Rigidbody2D>().velocity.y;
        currentXAccel += xAccel;

        if(Input.GetKeyDown(KeyCode.Space)) keysMode = true;
        if ((Input.GetKeyDown(KeyCode.Space)) || touch)
        {
            if (vy < 0) vy = 0;
            vy += ySpeed;
            playSound(boing);
            transform.GetComponent<Rigidbody2D>().transform.localScale = new Vector2(0.5f, 0.25f);
        }
        if((Input.GetKeyUp(KeyCode.Space)) || (!keysMode && (Input.touchCount == 0)))
        {
            transform.GetComponent<Rigidbody2D>().transform.localScale = new Vector2(0.5f, 0.5f);
        }

        vx = xSpeed + currentXAccel;

        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(vx, vy);
    }

    void playSound(GameObject _sound)
    {
        
                _sound.GetComponent<AudioSource>().Play();
        
        
    }

    public void exit()
    {
            Application.Quit();
    }

    public void toggleSounds()
    {
        shotgun.GetComponent<AudioSource>().enabled = !shotgun.GetComponent<AudioSource>().enabled;
        boing.GetComponent<AudioSource>().enabled = !boing.GetComponent<AudioSource>().enabled;
        coin.GetComponent<AudioSource>().enabled = !coin.GetComponent<AudioSource>().enabled;
        commentary.GetComponent<AudioSource>().enabled = !commentary.GetComponent<AudioSource>().enabled;
    }

    void soundControls()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S) || ((Input.touchCount == 5) && touch)) shotgun.GetComponent<AudioSource>().enabled = !shotgun.GetComponent<AudioSource>().enabled;
        if (Input.GetKeyDown(KeyCode.B) || ((Input.touchCount == 6) && touch)) boing.GetComponent<AudioSource>().enabled = !boing.GetComponent<AudioSource>().enabled;
        if (Input.GetKeyDown(KeyCode.C) || ((Input.touchCount == 7) && touch)) coin.GetComponent<AudioSource>().enabled = !coin.GetComponent<AudioSource>().enabled;
        if (Input.GetKeyDown(KeyCode.V) || ((Input.touchCount == 8) && touch)) commentary.GetComponent<AudioSource>().enabled = !commentary.GetComponent<AudioSource>().enabled;
        */
        //Mobile override
        
        boing.GetComponent<AudioSource>().enabled = true;
        coin.GetComponent<AudioSource>().enabled = true;
        commentary.GetComponent<AudioSource>().enabled = true;
        
    }

    void Update()
    {

        touch = ((bool)(Input.touchCount > prevTouchCount));
        prevTouchCount = Input.touchCount;
        soundControls();
        speedUpdate();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exit();
        }


    }
}

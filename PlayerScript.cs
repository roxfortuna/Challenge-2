using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;
    public Text winText;
    public AudioSource musicSource;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;


    private int scoreValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.text = "";
        musicSource.clip = musicClipOne;
        musicSource.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }

        if (scoreValue >= 4 )
        {
            winText.text = winText.text = "You win! " +
                  "Game created by Rox Follett!";
            musicSource.clip = musicClipOne;
            musicSource.Stop();
            musicSource.clip = musicClipTwo;
            musicSource.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))

            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private bool started = false;

    public AudioSource hitSound, blipSound;

    public TextMeshProUGUI textMeshPro;

    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetKeyDown("space"))
            {
                Launch();
                started = true;
                textMeshPro.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                hitSound.Play();
                break;
            case "Untagged":
                blipSound.Play();
                break;
        }
    }
    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        textMeshPro.enabled = true;
        started = false;
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }
}

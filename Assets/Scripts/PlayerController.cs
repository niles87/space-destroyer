using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movePlayer;
    public float speed;
    public int level;
    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sprite;
    private string DESTROYED_ANIMATION = "Destroyed";
    private bool isHit = false;

    //private GameObject[] boundries = GameObject.FindGameObjectsWithTag("Boundry");

    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerKeyboard();
        AnimatePlayer();
        FireLaser();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Boundry"))
        {
            Vector3 currentPos = transform.position;
            transform.position = new Vector3(currentPos.x * -1, currentPos.y, currentPos.z);
        } else if (collision.gameObject.CompareTag("Enemy"))
        {
            isHit = true;
        }


    }

    void MovePlayerKeyboard()
    {
        movePlayer = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * movePlayer * speed);
    }

    void AnimatePlayer()
    {
        if (isHit)
        {
            anim.SetBool(DESTROYED_ANIMATION, true);
        } else
        {
            anim.SetBool(DESTROYED_ANIMATION, false);
        }
        
    }
    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1"))
        {
            Debug.Log(Input.GetKeyDown(KeyCode.Space));
            Debug.Log(Input.GetButtonDown("Fire1"));
            Debug.Log(level);
        }
        //new LaserBlast(transform.position, level);
    }
}

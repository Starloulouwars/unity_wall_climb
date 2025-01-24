using System;
using System.Diagnostics;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    private Rigidbody2D _rb;

    

    public int _JumpForce = 35;

    public int _Speed = 7;

    public TextMeshProUGUI TextScore;

    private int _score = 0;

    private Animator _animator;

    public bool _touchFloor = false;

    public bool _touchClimbWall = false;

    public bool _climb = true;    

    private Vector3 localScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxis("Horizontal");

        _rb.linearVelocity = new Vector2(movement * _Speed, _rb.linearVelocityY);

        if(Input.GetButtonDown("Jump") && _touchFloor){
            _rb.AddForce(new Vector2(_rb.linearVelocityX, _JumpForce * 10));
        }

        _animator.SetBool("move", movement!=0);
        _animator.SetBool("jump", _touchFloor != true );

        if(movement != 0){
            localScale = transform.localScale;
            localScale.x = movement > 0 ? 1f : -1f; 
            transform.localScale = localScale;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            if (_climb == true && _touchClimbWall == true){

                _rb.linearVelocity = Vector2.zero;
                Vector3 localScale = transform.localScale;

                GetComponent<Collider2D>().enabled = false;

                Vector2 climbDirection = new Vector2(localScale.x * 0.5f, 4f);

                GetComponent<Collider2D>().enabled = true;

                Vector2 newPosition = (Vector2)transform.position + climbDirection;

                transform.Translate(newPosition);

                UnityEngine.Debug.Log("Escalade en cours : " + climbDirection + " | Local Scale: " + localScale);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collider){

        if(collider.gameObject.CompareTag("Money")){
            _score ++;
            TextScore.text = "Score : "+_score;
            Destroy(collider.gameObject);
        }

    }
}
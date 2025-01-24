using UnityEngine;

public class floorCheck : MonoBehaviour
{

    public Player _player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider){

            
        if(collider.gameObject.CompareTag("floor")){
            _player._touchFloor = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collider){

        if(collider.gameObject.CompareTag("floor")){
             _player._touchFloor = false;
        }

    }
}

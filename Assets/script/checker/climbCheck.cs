using UnityEngine;

public class climbCheck : MonoBehaviour
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
        if(collider.gameObject.CompareTag("ledge")){
            _player._climb = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.CompareTag("ledge")){
            _player._climb = true;
        }
    }
}

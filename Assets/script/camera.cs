using System;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public float interpolateSpeed = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 interpolation = Vector2.Lerp(transform.position, player.transform.position, interpolateSpeed*Time.deltaTime);
        transform.position = new Vector3(interpolation.x, interpolation.y, -10f);
    }
}
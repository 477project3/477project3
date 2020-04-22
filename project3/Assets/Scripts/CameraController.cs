using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject backwall;
    public GameObject player;
    public float min_speed = 1;
   
    // Update is called once per frame
    void Update()
    {
        //Vector3 movement = new Vector3(min_speed, 0, 0) * Time.deltaTime;
        Vector3 movement = new Vector3(0, 0, 0) * Time.deltaTime;

        // Speed up to maintain pace with the player if the player moves forward
        float catchup = player.transform.position.x - transform.position.x + Camera.main.orthographicSize;
        if (catchup > 0) { movement.x += (float) System.Math.Pow(catchup, 2) * Time.deltaTime / 5; }

        // Adapt to the Y position of the player
        float y_diff = transform.position.y - player.transform.position.y;
        if (System.Math.Abs(y_diff) > Camera.main.orthographicSize / 5) { movement.y -= (float) System.Math.Pow(y_diff, 2) * System.Math.Sign(y_diff) * Time.deltaTime; }

        transform.position += movement;
        backwall.transform.position = transform.position + new Vector3(-11.2f, 0, 0);
    }
}

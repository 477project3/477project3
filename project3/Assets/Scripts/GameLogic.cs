using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    public GameObject ball;

    private List<GameObject> balls;

    // Start is called before the first frame update
    void Start()
    {
        balls = new List<GameObject>();
        for (int i = 0; i < 1; i++)
        {
            balls.Add(Instantiate(ball));
            balls[i].transform.position = spawn_ball_position();
            balls[i].GetComponent<Rigidbody2D>().velocity = spawn_ball_velocity();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject b;
        CircleCollider2D cc;
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i] == null) continue;
            b = balls[i];
            cc = b.GetComponent<CircleCollider2D>();
            if (cc.bounds.center.y + cc.bounds.extents.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
            {
                // Re-initialize the object
                b.transform.position = spawn_ball_position();
                b.GetComponent<Rigidbody2D>().velocity = spawn_ball_velocity();
            }
        }
    }

    Vector3 spawn_ball_velocity()
    {
        return new Vector3(Random.Range(-5, 3), Random.Range(-5, 0), 0);
    }

    Vector3 spawn_ball_position()
    {
        return new Vector3(Camera.main.transform.position.x + Random.Range(0f, Camera.main.orthographicSize * 1), Camera.main.transform.position.y + Camera.main.orthographicSize / 2, 0);
    }
}

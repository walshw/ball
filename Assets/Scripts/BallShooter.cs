using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public Vector3 direction;
    public float speed = 1f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnAndShoot), 1f, 1f);
    }
    
    void SpawnAndShoot()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);

        Destroy(ball, 5f);
    }
}

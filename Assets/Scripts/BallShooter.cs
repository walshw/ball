using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;
    public float speed = 1f;
    public float turningArc = 30f;
    public float turningDuration = 3f;
    private float targetDegree;
    private float startDegree = 0;
    private float currentDegree;
    private float timeElapsed = 0;
    private bool startTurning;
    void Start()
    {
        targetDegree = -turningArc;
        InvokeRepeating(nameof(SpawnAndShoot), 1f, .25f);
    }

    void SpawnAndShoot()
    {
        float degs = 180 + currentDegree;
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Vector3 direction = new Vector3(Mathf.Sin(degs * Mathf.Deg2Rad), Mathf.Cos(degs * Mathf.Deg2Rad), 0f);
        ball.GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        Debug.DrawLine(transform.position, transform.position + direction, Color.green, 0.5f);
        startTurning = true;
        Destroy(ball, 5f);
    }

    void FixedUpdate()
    {
        Vector3 wizard = new Vector3(Mathf.Sin((180 + currentDegree) * Mathf.Deg2Rad) * 5, Mathf.Cos((180 + currentDegree) * Mathf.Deg2Rad) * 5, 0f);
        Debug.DrawLine(transform.position, transform.position + wizard, Color.blue);

        if (!startTurning)
        {
            return;
        }

        if (timeElapsed < turningDuration)
        {
            currentDegree = Mathf.LerpAngle(startDegree, targetDegree, timeElapsed / turningDuration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0;
            currentDegree = targetDegree;
            startDegree = targetDegree;
            targetDegree = -targetDegree;
        }
    }
}

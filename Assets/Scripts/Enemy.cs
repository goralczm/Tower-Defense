using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;

    private int _currPointIndex;
    private Transform[] _points;

    private void Start()
    {
        _points = Waypoints.points;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _points[_currPointIndex].position, Time.deltaTime * speed);
        if (transform.position == _points[_currPointIndex].position)
        {
            if (_currPointIndex != _points.Length - 1)
                _currPointIndex++;
            else
                Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}

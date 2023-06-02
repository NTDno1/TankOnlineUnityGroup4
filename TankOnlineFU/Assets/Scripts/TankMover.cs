using System;
using System.Collections;
using System.Collections.Generic;
using Entity;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    // public Collider2D trees;
    void Start()
    {
        speed = 1;
        // trees = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(trees.name);  
         Vector3 currentPosition = transform.position;
        currentPosition.z = 0f; 
    }


    public Vector3 Move(Direction direction)
    {
        var currentPos = gameObject.transform.position;
        switch (direction)
        {
            case Direction.Down:
                currentPos.y -= speed*Time.deltaTime;
                break;
            case Direction.Left:
                currentPos.x -= speed*Time.deltaTime;
                break;
            case Direction.Right:
                currentPos.x += speed*Time.deltaTime;
                break;
            case Direction.Up:
                currentPos.y += speed*Time.deltaTime;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        gameObject.transform.position = currentPos;
        return currentPos;
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trees"))
        {
            // Xử lý khi có va chạm với đối tượng có tag là "Enemy"
            Debug.Log("Đã xảy ra va chạm với đối tượng Enemy");
        }
    }
}
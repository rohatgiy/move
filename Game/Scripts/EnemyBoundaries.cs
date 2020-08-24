using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoundaries : MonoBehaviour
{

    private float minX, maxX, minY, maxY;
    private float enemyRadius;
    private Rigidbody2D enemy;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D enemyCollider = GetComponent<BoxCollider2D>();
        enemyRadius = enemyCollider.bounds.extents.x;
        enemy = GetComponent<Rigidbody2D>();

        minX = -10 + enemyRadius;
        maxX = 10 - enemyRadius;
        minY = -2 + enemyRadius;
        maxY = 9 - enemyRadius;
    }

    // Update is called once per frame
    void Update()
    {
        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX) pos.x = minX;
        if (pos.x > maxX) pos.x = maxX;

        // vertical contraint
        if (pos.y < minY)
        { 
            Destroy(GetComponent<BoxCollider2D>());
            Destroy(GetComponent<SpriteRenderer>());

        }
        if (pos.y > maxY) pos.y = maxY;

        // Update position
        transform.position = pos;
 
}
}

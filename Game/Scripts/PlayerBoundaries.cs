using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerBoundaries : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    private float playerRadius;
    private Rigidbody2D player;
    public GameObject gameOver, restartButton, leaderboardsButton, privacyPolicy;
    public static bool isDead = false;




    void Start()
    {


        privacyPolicy.SetActive(false);
        leaderboardsButton.SetActive(false);
        gameOver.SetActive(false);
        restartButton.SetActive(false);

        // If you want the min max values to update if the resolution changes 
        // set them in update else set them in Start
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));
        CircleCollider2D playerCollider = GetComponent<CircleCollider2D>();
        playerRadius = playerCollider.bounds.extents.x;
        player = GetComponent<Rigidbody2D>();

        minX = bottomCorner.x + playerRadius;
        maxX = topCorner.x - playerRadius;
        minY = bottomCorner.y + playerRadius;
        maxY = topCorner.y - playerRadius;
    }

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
            privacyPolicy.SetActive(true);
            leaderboardsButton.SetActive(true);
            gameOver.SetActive(true);
            restartButton.SetActive(true);
            isDead = true;
            Destroy(GetComponent<CircleCollider2D>());
            Destroy(GetComponent<SpriteRenderer>());



        }
        if (pos.y > maxY) pos.y = maxY;

        // Update position
        transform.position = pos;
    }
}
   

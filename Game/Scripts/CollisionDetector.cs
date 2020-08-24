using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector: MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject gameOver, restartButton, leaderboardsButton, privacyPolicy;
    public static bool isDead = false;
    
    

    void Start()
    {
        privacyPolicy.SetActive(false);
        leaderboardsButton.SetActive(false);
        gameOver.SetActive(false);
        restartButton.SetActive(false);
        player = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
      
            float moveHorizontal = Input.GetAxis("Mouse X");

            Vector2 movementHorizontal = new Vector2(moveHorizontal, 0.0f);

            player.AddForce(movementHorizontal * 10);

        
        
    }

    void OnCollisionEnter2D (Collision2D c)
    {
        if (c.gameObject.tag.Equals("Enemy"))
        {
            privacyPolicy.SetActive(true);
            leaderboardsButton.SetActive(true);
            gameOver.SetActive(true);
            restartButton.SetActive(true);
            isDead = true;
            Destroy(GetComponent<CircleCollider2D>());
            Destroy(GetComponent<SpriteRenderer>());
            

        }
    }
}

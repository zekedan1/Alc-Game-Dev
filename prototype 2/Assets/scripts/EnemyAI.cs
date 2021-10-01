using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{  
    public Transform player;
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb; 
    private Vector2 Movement;
    // Start is called before the first frame update   
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frames
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        Movement = direction;
    } 
    private void FixedUpdate() {
        moveCharacter(Movement);

    }
    void moveCharacter(Vector2 Direction){
        rb.MovePosition((Vector2)transform.position + (Direction * moveSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("MagicMissle"))
        {
        Destroy(gameObject);
        }
    }
}

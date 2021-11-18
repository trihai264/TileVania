using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D erb;


    // Start is called before the first frame update
    void Start()
    {
        erb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        erb.velocity = new Vector2(moveSpeed, 0f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipFacing();
    }

    void FlipFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(erb.velocity.x)), 1f);
    }
}

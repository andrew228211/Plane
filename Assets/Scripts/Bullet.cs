using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 direction;

    public Collider2D collider2D;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);
    }
    public void DestroyBullet()
    {
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerController>().TakeDamge();
        }
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<Enemy>().TakeDamge();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float damage;
    public float hitWaitTime = 0.5f;
    public float health = 10f;
    public float knockBackTime = 0.5f;
    public int expToGive = 1;

    private float knockBackCounter;
    private Transform target;
    private float hitCounter;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
        moveSpeed = Random.Range(moveSpeed * 0.8f, moveSpeed * 1.4f);
    }
    private void Update()
    {
        if(knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;

            if(moveSpeed > 0)
            {
                moveSpeed = -moveSpeed * 2f; 
            }
            if(knockBackCounter <= 0)
            {
                moveSpeed = Mathf.Abs(moveSpeed * 0.5f);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = (target.position - transform.position).normalized * moveSpeed;
        if(hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player =collision.gameObject.GetComponent<PlayerHealth>();
        if (player)
        {
            player.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }
    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if(health <= 0)
        {
            Destroy(gameObject);

            ExperienceLevelController.instance.SpawnExp(transform.position, expToGive);
        }

        DamageNumberController.instance.SpawnDamage(damageToTake,transform.position);
    }

    public void TakeDamage(float damageToTake, bool shouldKnockBack)
    {
        TakeDamage(damageToTake);

        if(shouldKnockBack)
        {
            knockBackCounter = knockBackTime; 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;

    [SerializeField]
    private int health;
    private int xpAmount;
    // Start is called before the first frame update
    void OnEnable()
    {
        health = 5;
        xpAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health <= 0)
        {
            ScoreTracker.scoreValue++;
            EventManager.instance.AddExperience(xpAmount);
            Destroy(gameObject);
        }
    }
}

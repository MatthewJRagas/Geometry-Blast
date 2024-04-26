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
    private int rndNum;
    // Start is called before the first frame update
    void OnEnable()
    {
        health = 5;
        xpAmount = 1;

        rndNum = UnityEngine.Random.Range(1, 100);

        if(rndNum <= 25)
        {
            transform.rotation = new Quaternion(0,0,0,0);
        }
        else if(rndNum > 25 && rndNum <= 50)
        {
            transform.rotation = new Quaternion(0, 0, 90, 0);
        }
        else if(rndNum > 50 && rndNum <= 75)
        {
            transform.rotation = new Quaternion(0, 0, 180, 0);
        }
        else if(rndNum > 75 && rndNum <= 100)
        {
            transform.rotation = new Quaternion(0, 0, -90, 0);
        }
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

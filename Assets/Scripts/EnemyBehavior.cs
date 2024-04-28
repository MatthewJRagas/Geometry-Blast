using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;

    public Camera camera;
    public Transform textTransform;

    [SerializeField] int health, xpAmount, rndNum;
    
    TextMeshProUGUI lives;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        health = UnityEngine.Random.Range(EventManager.enemyMinHealth, EventManager.enemyMaxHealth);
        lives = GetComponentInChildren<TextMeshProUGUI>();
        xpAmount = 1;

        rndNum = UnityEngine.Random.Range(1, 100);

        if (rndNum <= 25)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (rndNum > 25 && rndNum <= 50)
        {
            transform.rotation = new Quaternion(0, 0, 90, 0);
        }
        else if (rndNum > 50 && rndNum <= 75)
        {
            transform.rotation = new Quaternion(0, 0, 180, 0);
        }
        else if (rndNum > 75 && rndNum <= 100)
        {
            transform.rotation = new Quaternion(0, 0, -90, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        lives.text = health.ToString();

        textTransform.rotation = camera.transform.rotation;
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

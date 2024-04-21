using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireRate;
    public float attackTimer;

    private Vector3 testPos;
    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        fireRate = 1;
        attackTimer = 1 / fireRate;
    }
    // Update is called once per frame
    void Update()
    {
        testPos = Input.mousePosition;
        Debug.Log(testPos);
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if((attackTimer -= Time.deltaTime) <= 0)
        {
            Shoot();
            attackTimer = 1 / fireRate;
        }        
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Vector3 direction = mousePos - transform.position;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;
        
    }
}

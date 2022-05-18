using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialShooter : MonoBehaviour
{
    public GameObject FireBallPrefab;
    public Transform FirePoint;
    public float FireballSpeed = 20f;
    public float FireballDelay = 5f;
    public float damage = 1;
    public bool CanShoot = true;
    public float StartDelay;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        FirePoint = transform.GetChild(0);
        timer = StartDelay;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (CanShoot)
            {

                StartCoroutine(Shoot());

            }
        }

        
    }

    public IEnumerator Shoot()
    {



            // Creates the fireball at the firepoint position and rotation
        GameObject fireball = Instantiate(FireBallPrefab, FirePoint.position, FirePoint.rotation);
            

               

            // Add force to the fireball
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * FireballSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);

        fireball.GetComponent<Fireball>().damage = damage;
        fireball.GetComponent<Fireball>().IsEdgeball = true;
        fireball.GetComponent<Fireball>().IsSpecial = true;


        // Makes it so the shooter can't shoot until the amount of seconds in FireballDelay
        CanShoot = false;
        yield return new WaitForSeconds(FireballDelay);
        CanShoot = true;
        



    }

}

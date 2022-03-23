using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Fireball(Clone)")
        {
            Fireball fireball = collision.GetComponent<Fireball>();
            int tremp = Random.Range(1, 4);
            string hemp = "";
            if (tremp == 1)
            {
                hemp = "Bottom";
            }

            else if (tremp == 2)
            {
                hemp = "Top";
            }

            else if (tremp == 3)
            {
                hemp = "Right";
            }

            else if (tremp == 4)
            {
                hemp = "Left";
            }

            transform.parent.parent.parent.parent.Find(hemp).GetComponent<EdgeTeleporter>().Teleport(fireball);

            
            
        }
    }
}

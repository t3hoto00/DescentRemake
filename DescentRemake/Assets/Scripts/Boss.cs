using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    int health = 100;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "BulletPrefab(Clone)")
        {
            health = health -10;
            if (health == 0)
            {
                Destroy(this.gameObject);
            }
        }
        else if (col.gameObject.name == "MissilePrefab(Clone)")
        {
            print("Raketti osui");
            health = health -10;
            if(health == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

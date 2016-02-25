using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {

    public GameObject door;
    
    private KeyPickUp keyPickUp;
    int health = 1;
    bool doorLocked = false;
    bool keyFindGui = false;

    void Start()
    {
        keyPickUp = GetComponentInChildren<KeyPickUp>();
    }


    void OnTriggerEnter(Collider col)
    {
        if (keyPickUp.keyCollected == true)
        {
            if (col.gameObject.name == "BulletPrefab(Clone)")
            {
                health--;
                if (health == 0)
                {
                    Destroy(this.gameObject);
                    door.GetComponent<Animator>().Play("DoorMove");
                }
            }
            else if (col.gameObject.name == "MissilePrefab(Clone)")
            {
                health = 0;
                Destroy(this.gameObject);
                door.GetComponent<Animator>().Play("DoorMove");
            }
        }
        else
        {
            if (col.gameObject.name == "BulletPrefab(Clone)")
            {
                doorLocked = true;
                StartCoroutine(lockGuiText(3.0F));    
            }

        }
    }

    public void keyfindGui()
    {
            keyFindGui = true;

            StartCoroutine(keyKolGui(3.0F));
        
    }

    IEnumerator lockGuiText(float time)
    {
        yield return new WaitForSeconds(time);
        doorLocked = false;

    }

    IEnumerator keyKolGui(float guiTime)
    {
        yield return new WaitForSeconds(guiTime);
        keyFindGui = false;

    }

    void OnGUI()
    {
        if (doorLocked == true)
        {
            GUILayout.Label("The door is locked. Find a key.");
        }

        if(keyFindGui == true)
        {
            GUILayout.Label("You found a key!");
        }
    }
}

using UnityEngine;
using System.Collections;

public class KeyPickUp : MonoBehaviour {

    public bool keyCollected = false;
    bool keyGui = false;
    private LockedDoor lockedDoor;

    void Start()
    {
        lockedDoor = GetComponentInParent<LockedDoor>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "PlayerCockpit")
        {
            print("Avain löytyi!");
            keyCollected = true;
            lockedDoor.keyfindGui();
            Destroy(this.gameObject);
        }
    }

    
}

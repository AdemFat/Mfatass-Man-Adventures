using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAndChest : MonoBehaviour
{
    public Animator door;

    public void OpenDoor()
    {
        door.SetBool("open", true);
    }

}

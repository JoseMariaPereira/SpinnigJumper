using com.flyingcrow.jumper.events;
using com.flyingcrow.jumper.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public EventManager eventManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            eventManager.InvokeGravity();
        }
    }
}

using com.flyingcrow.jumper.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.flyingcrow.jumper.ground
{
    [RequireComponent(typeof(Collider2D))]
    public class DeathPit : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                player.KillPlayer();
            }
        }
    }
}

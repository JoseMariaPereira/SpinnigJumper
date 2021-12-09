using com.flyingcrow.jumper.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.flyingcrow.jumper.ground
{
    [RequireComponent(typeof(Collider2D))]
    public class Spike : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                player.KillPlayer();
            }
        }
    }
}

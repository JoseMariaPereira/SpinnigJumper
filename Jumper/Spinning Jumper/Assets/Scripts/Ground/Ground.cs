using com.flyingcrow.jumper.player;
using UnityEngine;

namespace com.flyingcrow.jumper.ground
{
    [RequireComponent(typeof(Collider2D))]
    public class Ground : MonoBehaviour
    {
        private Vector2 gravityDirection = Vector2.down;

        public void ChangeGravity()
        {
            gravityDirection *= -1;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

            Player player = collision.gameObject.GetComponent<Player>();
            if (player)
            {
                foreach (ContactPoint2D contact in collision.contacts)
                {
                    if (Vector2.Distance(contact.normal, gravityDirection) <= 0.99f)
                    {
                        player.Land();
                    }
                    else
                    {
                        player.KillPlayer();
                    }
                }
            }
        }
    }
}


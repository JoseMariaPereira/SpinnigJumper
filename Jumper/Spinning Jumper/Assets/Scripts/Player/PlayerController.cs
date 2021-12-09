using com.flyingcrow.jumper.events;
using com.flyingcrow.jumper.player;
using UnityEngine;


namespace com.flyingcrow.jumper.controller
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField]
        private Player player;
        [SerializeField]
        private Vector2 startPosition;
        [SerializeField]
        private EventManager eventManager;

        private void Start()
        {
            if (player == null) {
                Debug.LogWarning("No player found!");
            }
            if (!eventManager)
            {
                Debug.LogWarning("No eventManager found!");
            }
            eventManager.SubscribeRestarting(RestartPlayer);
            eventManager.SubscribeGravity(ChangeGravity);
        }

        private void Update()
        {
            if (!player.IsJumping() && Input.GetKey(KeyCode.Space))
            {
                player.Jump();
            }

            if (player.IsPlayerDead())
            {
                eventManager.InvokePlayerDied();
            }
        }

        public void RestartPlayer()
        {
            player.transform.position = new Vector3(startPosition.x, startPosition.y);
            player.Revive();
        }

        public void ChangeGravity()
        {
            player.ChangeGravity();
        }
    }
}

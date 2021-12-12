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
        private bool isGravityDown = true;
        private bool dead = false;
        private bool dying = false;

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

            if (player.PlayerIsDying() && !dying)
            {
                eventManager.InvokePlayerDying();
                dying = true;
                dead = false;
            }

            if (player.IsPlayerDead() && !dead)
            {
                eventManager.InvokePlayerDead();
                dead = true;
            }
        }

        public void RestartPlayer()
        {
            player.transform.position = new Vector3(startPosition.x, startPosition.y);
            dead = false;
            dying = false;
            player.Revive();
            if (!isGravityDown)
            {
                eventManager.InvokeGravity();
            }
        }

        public void ChangeGravity()
        {
            player.ChangeGravity();
            isGravityDown = !isGravityDown;
        }

        public Sprite GetPlayerSprite()
        {
            return player.GetSprite();
        }

        public float GetStartPosition()
        {
            return startPosition.x;
        }
    }
}

using UnityEngine;

namespace com.flyingcrow.jumper.player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private bool jumping = true;
        [SerializeField]
        [Range(1, 10)]
        private float jumpForce;
        private int jumpMultiplyer = 300;
        private bool isDead = false;
        private Rigidbody2D rigidBody;
        [SerializeField]
        private PlayerSpriteHandler spriteHandler;

        private float gameSpeed = 1;
        private float gravity;
        private Vector2 velocity;

        private void Start()
        {
            rigidBody = this.GetComponent<Rigidbody2D>();
            gravity = rigidBody.gravityScale;
            velocity = rigidBody.velocity;
            spriteHandler.changeGravity(rigidBody.gravityScale > 0);
        }

        private void Update()
        {
            if (!jumping)
            {
                spriteHandler.RotateTowardsTarget(jumpForce * gameSpeed);
            } 
            else
            {
                spriteHandler.RotateTowardsTarget(spriteHandler.transform.eulerAngles + Vector3.back * 100 * (rigidBody.gravityScale > 0 ? 1 : -1), jumpForce * 2 * gameSpeed);
            }
        }

        public bool IsJumping()
        {
            return jumping;
        }

        public bool IsPlayerDead()
        {
            return isDead && spriteHandler.NoDeadAnimation();
        }

        public bool PlayerIsDying()
        {
            return isDead;
        }

        public void Revive()
        {
            gameSpeed = 1;
            rigidBody.gravityScale = gravity;
            rigidBody.velocity = Vector2.zero;
            isDead = false; 
            jumping = true;
            setParticleSystem();
            spriteHandler.Revive();
        }

        public void Jump()
        {
            jumping = true;
            setParticleSystem();
            rigidBody.AddForce(Vector2.up * jumpForce * jumpMultiplyer * (rigidBody.gravityScale > 0 ? 1 : -1));
        }

        public void Land()
        {
            jumping = false;
            setParticleSystem();
            rigidBody.velocity = Vector2.zero;
        }

        public void KillPlayer()
        {
            gravity = rigidBody.gravityScale;
            isDead = true;
            spriteHandler.PlayDead();
        }

        public void Falling()
        {
            jumping = true;
            setParticleSystem();
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            Falling();
        }

        public void ChangeGravity()
        {
            rigidBody.gravityScale *= -1;
            spriteHandler.changeGravity(rigidBody.gravityScale > 0);
        }

        public void setParticleSystem()
        {
            spriteHandler.EnableDisableParticleSystem(!jumping);
        }

        public Sprite GetSprite()
        {
            return spriteHandler.GetCompletedSprite();
        }

        public void ResumeGame()
        {
            gameSpeed = 1;
            rigidBody.gravityScale = gravity;
            rigidBody.velocity = velocity;
        }

        public void PauseGame()
        {
            gameSpeed = 0;
            gravity = rigidBody.gravityScale;
            velocity = rigidBody.velocity;
            rigidBody.velocity = Vector2.zero;
            rigidBody.gravityScale = 0;
        }
    }
}


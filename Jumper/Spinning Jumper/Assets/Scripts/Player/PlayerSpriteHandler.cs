using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.flyingcrow.jumper.player
{
    public class PlayerSpriteHandler : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem groundParticleSystem;
        [SerializeField]
        private ParticleSystem topParticleSystem;
        [SerializeField]
        private ParticleSystem bottomParticleSystem;
        [SerializeField]
        private ParticleSystem deadParticleSystem;
        [SerializeField]
        private ParticleSystem deadParticleSystem2;
        [SerializeField]
        private Sprite completedSprite;
        [SerializeField]
        private List<SpritesContainer> playerSprites;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            completedSprite = CombineSprite();
            spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = completedSprite;
            spriteRenderer.color = Color.white;
            bottomParticleSystem.textureSheetAnimation.SetSprite(0, completedSprite);
            topParticleSystem.textureSheetAnimation.SetSprite(0, completedSprite);
            deadParticleSystem.textureSheetAnimation.SetSprite(0, completedSprite);
            deadParticleSystem2.textureSheetAnimation.SetSprite(0, completedSprite);
            deadParticleSystem.Stop();
            deadParticleSystem2.Stop();
            groundParticleSystem = bottomParticleSystem;
        }

        private Sprite CombineSprite()
        {
            Texture2D newSprite = new Texture2D(100, 100);
            foreach (SpritesContainer container in playerSprites)
            {
                Sprite sprite = container.sprite;
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        Color spriteColor = sprite.texture.GetPixel(i, j);
                        if (spriteColor == Color.white)
                        {
                            spriteColor = container.color;
                        }
                        if (spriteColor.a != 1)
                        {
                            spriteColor = newSprite.GetPixel(i, j);
                        }
                        newSprite.SetPixel(i, j, spriteColor);
                    }
                }
            }
            newSprite.Apply();
            return Sprite.Create(newSprite, new Rect(0, 0, 100, 100), new Vector2(.5f, .5f));
        }

        public void RotateTowardsTarget(float jumpForce)
        {
            Vector3 rotationTarget = FindTarget();
            if (this.transform.eulerAngles != rotationTarget)
            {
                this.transform.eulerAngles = Vector3.MoveTowards(this.transform.eulerAngles, rotationTarget, Time.deltaTime * jumpForce * 250);
                if (Mathf.Abs(this.transform.eulerAngles.z - rotationTarget.z) < 1)
                {
                    this.transform.eulerAngles = rotationTarget;
                }
            }
        }

        public void RotateTowardsTarget(Vector3 rotationTarget, float jumpForce)
        {
            if (this.transform.eulerAngles != rotationTarget)
            {
                this.transform.eulerAngles = Vector3.MoveTowards(this.transform.eulerAngles, rotationTarget, Time.deltaTime * jumpForce * 40);
                if (Mathf.Abs(this.transform.eulerAngles.z - rotationTarget.z) < 1)
                {
                    this.transform.eulerAngles = rotationTarget;
                }
            }
        }

        public Vector3 SnapPosition()
        {
            if (this.transform.eulerAngles.z < 45 || this.transform.eulerAngles.z >= 315)
            {
                this.transform.eulerAngles = Vector3.zero;
            }
            else if (this.transform.eulerAngles.z < 135)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 90);
            }
            else if (this.transform.eulerAngles.z < 225)
            {
                this.transform.eulerAngles = new Vector3(0, 0, 180);
            }
            else
            {
                this.transform.eulerAngles = new Vector3(0, 0, 270);
            }
            return this.transform.eulerAngles;
        }

        public Vector3 FindTarget()
        {
            Vector3 rotationTarget;

            if (this.transform.eulerAngles.z < 45 || this.transform.eulerAngles.z >= 315)
            {
                rotationTarget = Vector3.zero;
            }
            else if (this.transform.eulerAngles.z < 135)
            {
                rotationTarget = new Vector3(0, 0, 90);
            }
            else if (this.transform.eulerAngles.z < 225)
            {
                rotationTarget = new Vector3(0, 0, 180);
            }
            else
            {
                rotationTarget = new Vector3(0, 0, 270);
            }
            return rotationTarget;
        }


        public void EnableDisableParticleSystem(bool enable)
        {
            if (enable && spriteRenderer.enabled)
            {
                groundParticleSystem.Play();
            }
            else
            {
                groundParticleSystem.Stop();
            }
        }

        public void changeGravity(bool gravityPositive)
        {
            if (gravityPositive)
            {
                topParticleSystem.Stop();
                groundParticleSystem = bottomParticleSystem;
            } 
            else
            {
                bottomParticleSystem.Stop();
                groundParticleSystem = topParticleSystem;
            }
        }

        public void PlayDead()
        {
            if (spriteRenderer.enabled)
            {
                deadParticleSystem.Play();
                deadParticleSystem2.Play();
                groundParticleSystem.Stop();
            }
            spriteRenderer.enabled = false;
        }

        public void Revive()
        {
            spriteRenderer.enabled = true;
            SnapPosition();
        }

        public bool NoDeadAnimation() {
            return deadParticleSystem.isStopped && deadParticleSystem2.isStopped;
        }
    }

    [System.Serializable]
    class SpritesContainer {
        public Sprite sprite;
        public Color color;
    }
}

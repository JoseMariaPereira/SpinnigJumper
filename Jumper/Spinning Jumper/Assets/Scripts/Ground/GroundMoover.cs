using com.flyingcrow.jumper.events;
using UnityEngine;
using System.Collections.Generic;
using com.flyingcrow.jumper.ground;

namespace com.flyingcrow.jumper.controller
{
    public class GroundMoover : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private EventManager eventManager;
        [SerializeField]
        private Transform groundRoot;
        [SerializeField]
        [Range(1, 10)]
        private float groundSpeed;
        private float speedMultiplier = 1;
        private List<Ground> grounds = new List<Ground>();
        private List<Spike> spikes = new List<Spike>();

        private Vector3 startPos;

        void Start()
        {
            if (groundRoot == null)
            {
                Debug.LogWarning("No Gorund Father found, not going to move!");
            }
            if (eventManager == null)
            {
                Debug.LogWarning("No eventManager found!");
            }
            eventManager.SubscribeRestarting(RestartGround);
            eventManager.SubscribeGravity(ChangeGravity);
            eventManager.SubscribePlayerDying(StopProgress);
            startPos = groundRoot.position;
            grounds.AddRange(groundRoot.GetComponentsInChildren<Ground>());
            spikes.AddRange(groundRoot.GetComponentsInChildren<Spike>());
        }
        // Update is called once per frame
        private void Update()
        {
            groundRoot.transform.position += Vector3.left * groundSpeed * Time.deltaTime * speedMultiplier;
        }

        public void StopProgress()
        {
            speedMultiplier = 0;
        }

        public void RestartGround()
        {
            groundRoot.transform.position = startPos;
            speedMultiplier = 1;
        }

        public void ChangeGravity()
        {
            grounds.ForEach(g => g.ChangeGravity());
        }

    }
}


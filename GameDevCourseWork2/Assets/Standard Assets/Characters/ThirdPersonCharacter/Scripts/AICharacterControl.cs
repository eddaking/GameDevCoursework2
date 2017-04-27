using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling

		protected bool paused;
		protected int timeToStartedMoving = 2;
		private Vector3 lastPosition = Vector3.zero;
        private bool move;
        private bool dead;
        private bool moveleft;
        private Vector3 deathplace;
        private float speed = 5f;
        private float walkmultiplierspeed = 0.6f;
		Rigidbody character_rigidb;
        Vector3 rockstartplace;


        private void Start()
        {   
            // get the components on the object we need ( should not be null due to require component so no need to check )
            character = GetComponent<ThirdPersonCharacter>();
			character_rigidb = GetComponent<Rigidbody>();
            moveleft = true;
			dead = false;
			paused = false;
            rockstartplace = GameObject.Find("rockObject").transform.position;
        }


        private void Update()
        {
            checkPauseMovement ();
			if (timeToStartMoving () && !paused)
            {
				lastPosition = transform.position;
				if (!dead)
                {
					if (moveleft)
                    {
						// Multiply by 0.5f to walk instead of run.
						character.Move (Vector3.left * walkmultiplierspeed, false, false);
					}
                    else
                    {
						character.Move (Vector3.right * walkmultiplierspeed, false, false);
					}
				}
                else
                {   
					float step = speed * Time.deltaTime;
					transform.position = Vector3.MoveTowards (transform.position, deathplace, step);
				}
			}

            
        }

		private void checkPauseMovement(){
			if (!paused) {
				lastPosition = transform.position;
			}
            else
            {
                // character.Move (character_rigidb.velocity.normalized * 0.2f, false, false);
                Vector3 move;
                if (moveleft)
                {
                    move = Vector3.left;
                }
                else
                {
                    move = Vector3.right;
                }
                character.Move (move * 0.3f, false, false);
                transform.position = lastPosition;
            }
		}

		protected bool timeToStartMoving(){
			return Time.timeSinceLevelLoad > timeToStartedMoving;
		}
    
        public void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "ball")
            {
                moveleft = false;
			}
            else if (col.gameObject.name == "rockObject" && timeToStartMoving() && rockstartplace != col.gameObject.transform.position)
            {
                print("You are dead!");
                print("rockstartplace:" + rockstartplace + "\t col.gameObject,transform.position:" + col.gameObject.transform.position);
                dead = true;
                deathplace = col.transform.position;
                deathplace = new Vector3(deathplace.x, deathplace.y-1000, deathplace.z);
            }
        }

		void OnPauseGame()
		{
            paused = true;
		}

		void OnResumeGame()
		{
            paused = false;
		}

		void Clickable()
        {
		}

    }
}

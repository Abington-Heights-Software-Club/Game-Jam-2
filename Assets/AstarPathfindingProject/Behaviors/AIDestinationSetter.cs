using UnityEngine;
using System.Collections;

namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;
		IAstarAI ai;

		void OnEnable () {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update () {

		}

		public void enemyMove () {
            //if (target != null && ai != null) ai.dsestination = target.position;
            Seeker seeker = GetComponent<Seeker>();
            seeker.StartPath(ai.position, target.position, OnPathComplete);

        }

        public void OnPathComplete (Path p) {
            float movementAmount = 0.2f;
            Vector3 direction = p.vectorPath[1] - p.vectorPath[0];
            if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
                //Move on the x Axis
                if(direction.x >= 0) {
                    //Move Right
                    transform.position = new Vector3(transform.position.x + movementAmount, transform.position.y);
                } else {
                    //Move Left
                    transform.position = new Vector3(transform.position.x - movementAmount, transform.position.y);
                }
            } else {
                //Move on the y axis
                if(direction.y >= 0) {
                    //Move Right
                    transform.position = new Vector3(transform.position.x, transform.position.y + movementAmount);
                } else {
                    //Move Left
                    transform.position = new Vector3(transform.position.x, transform.position.y - movementAmount);
                }
            } 
            // Debug.Log(p.vectorPath[0]);
            // Debug.Log(p.vectorPath[1]);
            // Debug.Log(direction);
        }
	}
}

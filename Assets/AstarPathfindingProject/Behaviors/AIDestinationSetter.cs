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
        public Vector3 movedPosition = Vector3.zero;
        public Vector3 movedDirection = Vector3.zero;

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
            movedPosition = Vector3.zero;
            movedDirection = Vector3.zero;
            Seeker seeker = GetComponent<Seeker>();
            seeker.StartPath(ai.position, target.position, OnPathComplete);

        }

        public void OnPathComplete (Path p) {
            movedPosition = Vector3.zero;
            movedDirection = Vector3.zero;
            Debug.Log("Path Calculated");
            Vector3 direction = p.vectorPath[1] - p.vectorPath[0];
            if(ai.position != target.position && Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
                //Move on the x Axis
                if(direction.x >= 0) {
                    //Move Right
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1.0f, LayerMask.GetMask("Wall"));
                    if(hit.collider != null) {
                        Debug.Log("Hit");
                        if(direction.y >= 0) {
                            //move up
                            movedPosition = new Vector3(transform.position.x, transform.position.y + 1);
                            movedDirection = Vector3.up;
                        } else {
                            //move down
                            movedPosition = new Vector3(transform.position.x, transform.position.y - 1);
                            movedDirection = Vector3.down;
                        }        
                    } else {
                        Debug.Log("No Hit");
                        //move normally
                        movedPosition = new Vector3(transform.position.x + 1, transform.position.y);
                        movedDirection = Vector3.right; 
                    }
                } else {
                    //Move Left
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 1.0f, LayerMask.GetMask("Wall"));
                    if(hit.collider != null) {
                        Debug.Log("Hit");
                        if(direction.y >= 0) {
                            //move up
                            movedPosition = new Vector3(transform.position.x, transform.position.y + 1);
                            movedDirection = Vector3.up;
                        } else {
                            //move down
                            movedPosition = new Vector3(transform.position.x, transform.position.y - 1);
                            movedDirection = Vector3.down;
                        }        
                    } else {
                        Debug.Log("No Hit");
                        //move normally
                        movedPosition = new Vector3(transform.position.x - 1, transform.position.y);
                        movedDirection = Vector3.left; 
                    }
                }
            } else if(ai.position != target.position) {
                //Move on the y axis
                if(direction.y >= 0) {
                    //Move Up
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 1.0f, LayerMask.GetMask("Wall"));
                    if(hit.collider != null) {
                        Debug.Log("Hit");
                        if(direction.y >= 0) {
                            //move right
                            movedPosition = new Vector3(transform.position.x + 1, transform.position.y);
                            movedDirection = Vector3.right;
                        } else {
                            //move left
                            movedPosition = new Vector3(transform.position.x - 1, transform.position.y);
                            movedDirection = Vector3.left;
                        }        
                    } else {
                        Debug.Log("No Hit");
                        //move normally
                        movedPosition = new Vector3(transform.position.x, transform.position.y + 1);
                        movedDirection = Vector3.up; 
                    }
                } else {
                    //Move Down
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.0f, LayerMask.GetMask("Wall"));
                    if(hit.collider != null) {
                        Debug.Log("Hit");
                        if(direction.x >= 0) {
                            //move right
                            movedPosition = new Vector3(transform.position.x + 1, transform.position.y);
                            movedDirection = Vector3.right;
                        } else {
                            //move left
                            movedPosition = new Vector3(transform.position.x - 1, transform.position.y);
                            movedDirection = Vector3.left;
                        }        
                    } else {
                        Debug.Log("No Hit");
                        //move normally
                        movedPosition = new Vector3(transform.position.x, transform.position.y - 1);
                        movedDirection = Vector3.down; 
                    }
                }
            }
            Debug.Log("Moved Position: " + movedPosition);
            Debug.Log("Moved Direction: " + movedDirection);
        }
	}
}

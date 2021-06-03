using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TrapTrigger : MonoBehaviour
{
    private Animator anim;
    public float scaleX;
    public float scaleY;
    public float GridSize;

    //Final State Machine
    private enum State { idle, touched }
    private State state = State.idle;

    //Type
    private enum Object { hole, lights, chandelier, fireplace, table, library }
    [SerializeField] private Object type;

    //Orientation
    private enum Orientation { UP, LEFT, DOWN, RIGHT }
    [SerializeField] private Orientation orientation;
 
   // [SerializeField] private GameObject Obstacle;

    // Start is called before the first frame update
    void Start()
    {
        if ((int)type <= 2) { gameObject.layer = 0; }
        else { gameObject.layer = 3; }

        anim = GetComponent<Animator>();
        switch (orientation)
        {

            case Orientation.UP:
                scaleX = 0;
                scaleY = +GridSize;
                break;

            case Orientation.DOWN:
                scaleX = 0;
                scaleY = -GridSize;
                break;

            case Orientation.LEFT:
                scaleX = -GridSize;
                scaleY = 0;
                break;

            case Orientation.RIGHT:
                scaleX = +GridSize;
                scaleY = 0;
                break;

            default:
                break;
        }

    }

    private void OnMouseDown()
    {
        //OLD CODE
        /*switch (type)
        {
            case Object.hole:
                ChangeAnimation(State.touched);
                gameObject.layer = 3;
                break;

            case Object.fireplace:
                ChangeAnimation(State.touched);
                Instantiate(Obstacle, new Vector3(transform.position.x + scaleX, transform.position.y + scaleY), new Quaternion());
                Instantiate(Obstacle, new Vector3(transform.position.x + 2 * scaleX, transform.position.y + 2 * scaleY), new Quaternion());
                break;

            case Object.chandelier:
                
                
                Instantiate(Obstacle, new Vector3(transform.position.x + GridSize, transform.position.y), new Quaternion());
                Instantiate(Obstacle, new Vector3(transform.position.x - GridSize, transform.position.y), new Quaternion());
                Instantiate(Obstacle, new Vector3(transform.position.x, transform.position.y + GridSize), new Quaternion());
                Instantiate(Obstacle, new Vector3(transform.position.x, transform.position.y - GridSize), new Quaternion());
                ChangeAnimation(State.touched);
                gameObject.layer = 3;
                break;

            case Object.library:
                ChangeAnimation(State.touched);
                Instantiate(Obstacle, new Vector3(transform.position.x + scaleX, transform.position.y + scaleY), new Quaternion());
                break;

            default:
                break;
        }*/

        //NEW CODE
        if (GameManager.StaticMaxTrap > 0)
        {

            switch (type)
            {
                case Object.hole:
                    GetComponent<hole>().enabled = true;
                    break;

                case Object.fireplace:
                    GetComponent<fireplace>().enabled = true;
                    break;

                case Object.chandelier:
                    GetComponent<chandelier>().enabled = true;
                    break;

                case Object.library:
                    GetComponent<library>().enabled = true;
                    break;

                default:
                    break;
            }
            AstarPath.active.Scan();
            GameManager.StaticMaxTrap--;
        }
    }

    private void ChangeAnimation(State newState)
    {

        //Keep the animation if the state doesn't change
        if (state == newState) return;

        //Play the animation
        //anim.Play(newState.ToString());
        Debug.LogWarning("anim");
        //Reasing state
        state = newState;
    }
}

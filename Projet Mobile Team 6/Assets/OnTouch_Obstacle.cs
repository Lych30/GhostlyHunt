using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch_Obstacle : MonoBehaviour
{
    private GraphUpdateScene gus;
    private Animator anim;
    private float scaleX;
    private float scaleY;


    //Final State Machine
    private enum State { idle, touched }
    private State state = State.idle;

    //Type
    private enum Object { hole, lights, chandelier, fireplace, table, library }
    [SerializeField] private Object type;

    //Orientation
    private enum Orientation { UP, LEFT, DOWN, RIGHT }
    [SerializeField] private Orientation orientation;

    [SerializeField] private Transform Obstacle;

    // Start is called before the first frame update
    void Start()
    {
        if ((int)type <= 2) { gameObject.layer = 0; }
        else { gameObject.layer = 3; }
            
        anim = GetComponent<Animator>();
        switch (orientation) {

            case Orientation.UP:
                scaleX = 0;
                scaleY = +1.59f;
                break;

            case Orientation.DOWN:
                scaleX = 0;
                scaleY = -1.59f;
                break;
            
            case Orientation.LEFT:
                scaleX = -1.59f;
                scaleY = 0;
                break;
            
            case Orientation.RIGHT:
                scaleX = +1.59f;
                scaleY = 0;
                break;

            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        switch (type)
        {
            case Object.hole:
                ChangeAnimation(State.touched);
                gameObject.layer = 3;
                break;

            case Object.fireplace:
                ChangeAnimation(State.touched);
                Instantiate(Obstacle, new Vector3(transform.position.x + scaleX, transform.position.y + scaleY), new Quaternion());
                Instantiate(Obstacle, new Vector3(transform.position.x + 2*scaleX, transform.position.y + 2*scaleY), new Quaternion());
                break;
                
            case Object.chandelier:
                ChangeAnimation(State.touched);
                gameObject.layer = 3;
                Instantiate(Obstacle, new Vector3(transform.position.x + 1.59f, transform.position.y), new Quaternion());
                Instantiate(Obstacle, new Vector3(transform.position.x - 1.59f, transform.position.y), new Quaternion());
                Instantiate(Obstacle, new Vector3(transform.position.x, transform.position.y + 1.59f), new Quaternion());
                Instantiate(Obstacle, new Vector3(transform.position.x, transform.position.y - 1.59f), new Quaternion());
                break;

            case Object.library:
                ChangeAnimation(State.touched);
                Instantiate(Obstacle, new Vector3(transform.position.x + scaleX, transform.position.y + scaleY), new Quaternion());
                break;

            default:
                break;
        }
    }

    private void ChangeAnimation(State newState)
    {

        //Keep the animation if the state doesn't change
        if (state == newState) return;

        //Play the animation
        anim.Play(newState.ToString());
        Debug.LogWarning("anim");
        //Reasing state
        state = newState;
    }
}

/*
 * Created By: Shawn Dean
 * Date Created: September 13, 2021
 * 
 * Last Edited By: 
 * Last Updated: September 15, 2021
 * 
 * Description: Player control movements
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool MouseLock = true; //Are we looking at mouse?
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    //public string FireAxis = "Fire1";
    public float MaxSpeed = 5f; //Speed
    private bool isGrounded;
    public float jumpForce = 0.2f;
    private Vector3 jumpUp;

    public Animator animator;
    private bool isFacingLeft = true;


    private Rigidbody ThisBody; //Var for the ship's rigidbody.

    // Awake is called before start
    void Awake()
    {
        ThisBody = GetComponent<Rigidbody>(); //Sets the object's rigidbody to a variable.
        jumpUp = new Vector3(0.0f, jumpForce, 0.0f);
    }//end Awake()

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            ThisBody.AddForce(jumpUp * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        float Horz = Input.GetAxis(HorzAxis);

        Vector3 MoveLeftRight = new Vector3(Horz, 0.0f, 0.0f);
        transform.position -= MoveLeftRight * MaxSpeed;

        animator.SetFloat("Speed", Mathf.Abs(Horz));
        
        if(Horz < 0 && !isFacingLeft)
        {
            Flip();
        }
        if(Horz > 0 && isFacingLeft)
        {
            Flip();
        }
    }//end FixedUpdate()

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.Rotate(0f, 180f, 0f);
    }
}

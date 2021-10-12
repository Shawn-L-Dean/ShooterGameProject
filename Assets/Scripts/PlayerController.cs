/*
 * Created By: Shawn Dean
 * Date Created: October 4, 2021
 * 
 * Last Edited By: Shawn Dean
 * Last Updated: October 7, 2021
 * 
 * Description: Player controls and movements
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string HorzAxis = "Horizontal";
    public float MaxSpeed = 5f; //Speed
    private bool isGrounded;
    public float jumpForce = 0.2f;
    private Vector3 JumpUp;

    public Animator animator;
    private bool isFacingLeft = true;


    private Rigidbody ThisBody; //Var for the players's rigidbody.

    // Awake is called before start
    void Awake()
    {
        ThisBody = GetComponent<Rigidbody>(); //Sets the object's rigidbody to a variable.
        JumpUp = new Vector3(0.0f, jumpForce, 0.0f);
    }//end Awake()

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            ThisBody.AddForce(JumpUp * jumpForce, ForceMode.Impulse);
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

//////////////////////////////////////////////////
// Author:              A_VOID
// Date created:        11/12/17
// Date last edited:    12/12/17
//////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
// A script which allows the parent GameObject to move in cardinal directions as long as its BoxCollider2D component remains entirely within the BoxCollider2D bounds of another GameObject tagged 'MovementArea'.
public class MoveWithinMovementArea : MonoBehaviour
{
    // The property used to get whether the BoxCollider2D of the parent GameObject is entirely within the BoxCollider2D bounds of another GameObject tagged 'MovementArea'.
    private bool IsWithinMovementArea
    {
        get
        {

            foreach (GameObject movementArea in GameObject.FindGameObjectsWithTag("MovementArea"))
            {
                BoxCollider2D thisCollider = GetComponent<BoxCollider2D>();
                BoxCollider2D movementAreaCollider = movementArea.GetComponent<BoxCollider2D>();

                if (movementAreaCollider.bounds.Contains(thisCollider.bounds.min) && movementAreaCollider.bounds.Contains(thisCollider.bounds.max))
                    return true;
            }


            return false;
        }
    }

    // Called when the script is loaded.
    private void Awake()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
    }

    // Called each time the gameplay logic is updated.
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector2.up * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector2.down * Time.deltaTime);

        Debug.Log(IsWithinMovementArea);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbingSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(0, 30f);

    bool isAlive = true;

    Rigidbody2D myRigidbody;
    Animator myAniamtor;
    Collider2D myFeet;
    Collider2D myBody;

    float gravityScaleAtStart;

    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAniamtor = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        myBody = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update() {
        if (isAlive) {
            Run();
            Jump();
            Climb();
            Die();
            FlipSprite();
        }
    }

    void Die() {
        if (myBody.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards"))) {
            myAniamtor.SetTrigger("Die");
            myRigidbody.velocity = deathKick;
            isAlive = false;
        }
    }

    void Run() {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // -1 ~ 1
        // Debug.Log(controlThrow * runSpeed * Time.deltaTime);
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        myAniamtor.SetBool("isRunning", Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon);
    }

    void Jump() {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            return;
        }

        Debug.Log("can jump");
        if (CrossPlatformInputManager.GetButtonDown("Jump")) {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            myRigidbody.velocity += jumpVelocity;
            // myRigidbody.AddForce(jumpVelocity);
        }
    }

    void Climb() {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing"))) {
            Debug.Log("nc");
            myAniamtor.SetBool("isClimbing", false);
            myRigidbody.gravityScale = gravityScaleAtStart;
            return;
        }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical"); // -1 ~ 1
        Vector2 climbVector = new Vector2(myRigidbody.velocity.x, controlThrow * climbingSpeed);
        myRigidbody.velocity = climbVector;
        myAniamtor.SetBool("isClimbing", Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon);
        myRigidbody.gravityScale = 0f;
    }

    void FlipSprite() {
        if (Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon) {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] float moveSpeed =2f;
    Rigidbody2D myRigidbody;

    void Start() {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(IsFacingRight()){
        myRigidbody.velocity = new Vector2(moveSpeed, 0);
        }
        else {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0);
        }
    }

    bool IsFacingRight() {
        return transform.localScale.x > 0;
    }
    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("OnTriggerExit2D");
        transform.localScale = new Vector2(-Mathf.Sign(myRigidbody.velocity.x), 1f);
    }
}

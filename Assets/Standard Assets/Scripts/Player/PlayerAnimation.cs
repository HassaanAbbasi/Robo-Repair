using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private PlayerMovement player;

    [SerializeField]
    private Rigidbody2D playerRB;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("MoveSpeed", Mathf.Abs(playerRB.velocity.x));
    }
}

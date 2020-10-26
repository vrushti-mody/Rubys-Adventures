using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{

    [SerializeField]
    private AudioClip jumpClip;
    private Rigidbody2D myBody;
    private float jumpForce = 8f, forwardForce = 0f;
    private bool canJump;
    private Button jumpBtn;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        jumpBtn = GameObject.Find("Jump Button").GetComponent<Button>();
        jumpBtn.onClick.AddListener(() => Jump()); 
    }

    public void Jump() {
        if (canJump) {
            canJump = false;
            // AudioSource.PlayClipAtPoint(jumpClip, transform.position);
            if (transform.position.x < 0) {
                forwardForce = 1f;
            } else {
                forwardForce = 0f;
            }
            myBody.velocity = new Vector2(forwardForce, jumpForce);
        }
    }

    public void Update() {
        if (Mathf.Abs(myBody.velocity.y) == 0) {
            canJump = true;
        }
    }
}

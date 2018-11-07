using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    private int count;
    public Text CountText;
    public Text WinText;
    void Start() {

        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = " ";
    }

    void FixedUpdate()
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveHorizontal,0.0f,MoveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText() {
        CountText.text = "Count:" + count.ToString();
        if (count>= 11) {
            WinText.text = "You Win!";
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public CharacterController CC;
    public float MoveSpeed;
    public float G = 9.8f;
    public float Mass = 1;
    public float YSpeed = 0;
    public float JumpImpulse;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = this.transform.eulerAngles;
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x -= Input.GetAxis("Mouse Y");
        this.transform.eulerAngles = rotation;

        Vector3 forward = this.transform.forward * Input.GetAxis("Vertical");
        Vector3 right = this.transform.right * Input.GetAxis("Horizontal");
        Vector3 SummaryVector = (forward + right) * MoveSpeed;
        SummaryVector.y = 0;
        if (!CC.isGrounded)
        {
            YSpeed -= (G * Time.deltaTime) * (Mass / 1000);
        }
        else
        {
            YSpeed = 0;
            if (Input.GetKey(KeyCode.Space))
            {
                YSpeed = JumpImpulse * (Mass / 1000);
            }
        }
        SummaryVector.y = YSpeed;

        CC.Move(SummaryVector);
    }
}

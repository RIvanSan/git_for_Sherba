using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController characterController;
    public float gravity = -9.8f;
    public float speed;
    public float JumpForce;
    private float JumpSpeed;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = 0;
        float vertical = 0;


        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (characterController.isGrounded)
        {
            JumpSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpSpeed = JumpForce;
            }
        }
        JumpSpeed += gravity * Time.deltaTime * 3f;
        Vector3 dir = new Vector3(vertical * speed * Time.deltaTime, JumpSpeed * Time.deltaTime, -horizontal * speed * Time.deltaTime);
        characterController.Move(dir);
    }
}
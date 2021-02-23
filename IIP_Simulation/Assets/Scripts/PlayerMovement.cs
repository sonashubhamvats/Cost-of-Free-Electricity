using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _thisCharacter;
    public float speed;
    Vector3 moveDirection=new Vector3(0f,0f,0f);
    private float temp;

    float current_x_rot;
    public Transform child_camera;
    public float sensitivity;
    private void Start()
    {
        
    }
    private void Awake()
    {
        _thisCharacter=GetComponent<CharacterController>();
    }
    private void Update()
    {
        checkcursor();

        CheckForMovement();
        MouseMovement();

    }
    void checkcursor()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState==CursorLockMode.Locked)
            {

                Cursor.lockState = CursorLockMode.None;
                
            }
            else if(Cursor.lockState==CursorLockMode.None)
            {
                
                Cursor.lockState = CursorLockMode.Locked;
                
            }
        }
    }
    public void MouseMovement()
    {
        transform.Rotate(0f,Input.GetAxisRaw("Mouse X")*sensitivity*Time.deltaTime,0f);
        current_x_rot-=Input.GetAxisRaw("Mouse Y")*sensitivity*Time.deltaTime;
        current_x_rot=Mathf.Clamp(current_x_rot,-80f,80f);
        child_camera.transform.localRotation=Quaternion.Euler(current_x_rot,0f,0f);
    }
    public void CheckForMovement()
    {
        Vector3 moveDirx = new Vector3(0f, 0f, 0f);
        Vector3 moveDirz = new Vector3(0f, 0f, 0f);
        Vector3 movediry=new Vector3(0f,0f,0f);
        if(Input.GetKey(KeyCode.Space))
        {
            movediry+=new Vector3(0f,1f,0f);
        }
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            movediry+=new Vector3(0f,-1f,0f);
        }
        moveDirx = transform.right * Input.GetAxis("Horizontal");
        moveDirz = transform.forward * Input.GetAxis("Vertical");
        moveDirection = ((moveDirx + moveDirz+movediry) * speed * Time.deltaTime);        
        _thisCharacter.Move(moveDirection);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float rotateSpd = 10f;
    public float movespd = 10f;
    public float gravity = -9.8f;
    Vector3 moveDirection = Vector3.zero;

    bool isDash = false;
    float jumpspd = 30.0f;
    float mouseX;
    float mouseY;

    CharacterController characterController;
    PlayerData playerData;
    ItemParming itemParm;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerData = GetComponent<PlayerData>();
        itemParm = GetComponent<ItemParming>();
    }

    private void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        itemParm.ItemSearch();

        Jump();
        Debug.Log(characterController.isGrounded);

        if (!characterController.isGrounded)
        {
            characterController.SimpleMove(new Vector3(transform.position.x, transform.position.y + gravity, transform.position.z) * Time.deltaTime);
        }

        if (Mathf.Abs(z)>0.0f)
        {    
            characterController.SimpleMove(transform.forward*z * movespd);
        }
        else if (Mathf.Abs(z)<0.0f)
        {
            characterController.SimpleMove(transform.forward * z * movespd);
        }

        if(Mathf.Abs(x)>0.0f)
        {
            Vector3 rightPos = transform.right;
            characterController.SimpleMove(rightPos*x*movespd);
        }
        OnDash();
        Jump();
        
        RotateChange();
    }

    IEnumerator reviveSt()
    {
        yield return new WaitForSeconds(1f);
        playerData.st += 1.0f;
    }

    void Jump()
    {
        if (characterController.isGrounded&&Input.GetKeyDown(KeyCode.Space))
        {
            moveDirection = new Vector3(transform.position.x, jumpspd, transform.position.z);
            characterController.Move(moveDirection* jumpspd*Time.deltaTime);
        }
    }

    void OnDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&&!isDash&&characterController.isGrounded)
        {
            StartCoroutine(Dash());
            StartCoroutine(reviveSt());
        }
        
    }

    IEnumerator Dash()
    {
        movespd *= 3;
        isDash = true;
        playerData.st -= 1.0f;
        yield return new WaitForSeconds(0.3f);
        movespd /= 3;
        isDash = false;
    }


    void RotateChange()
    {

        mouseY += Input.GetAxis("Mouse Y") * rotateSpd;
        mouseX += Input.GetAxis("Mouse X") * rotateSpd;
        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
        
    }

    void RotateXChange()
    {
       
    }
}

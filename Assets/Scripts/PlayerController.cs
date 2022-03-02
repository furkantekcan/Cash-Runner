using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float diamond_1Value = 10f;
    public float diamond_2Value = 20f;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float swerveSpeed = 0.5f;

    private Vector3 forwardMove;
    private Rigidbody rb;
    private float horMove;

    private float lastPosX;
    private float moveFactorX;
    private float swerveAmount;
    private float maxSwerveAmount = 0.5f;


    //private bool isGameStarted = false;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //SwerveInputSystem();
        //swerveAmount = swerveSpeed * moveFactorX;
        //swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        horMove = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //forwardMove = transform.forward+ new Vector3(swerveAmount, 0, 0);
        forwardMove = new Vector3(0,0,1) * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horMove * Time.fixedDeltaTime;
        if (!GameManager.Instance.isGameStarted)
        {
            return;            
        }
        
        rb.MovePosition(rb.position +  forwardMove + horizontalMove);
        animator.SetBool("isGameStarted", true);

    }

    //void SwerveInputSystem()
    //{ 
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        lastPosX = Input.mousePosition.x;
    //    }
    //    else if (Input.GetMouseButton(0))
    //    {
    //        moveFactorX = 50 * (Input.mousePosition.x - lastPosX);
    //        lastPosX = Input.mousePosition.x;
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
    //        moveFactorX = 0f;
    //    }
    //}

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    Debug.Log(hit.transform.name);

    //    if (hit.transform.name == "Finish")
    //    {
    //        PlayerManager.isLevelFinished = true;
    //        animator.SetBool("isLevelFinished", true);
    //        speed = 0f;
    //        swerveSpeed = 0f;
    //    }

    //}

    private void Die()
    {
        if (true)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Finish")
        {
            GameManager.Instance.SetGameFinished();
            animator.SetBool("isLevelFinished", true);
            speed = 0f;
            swerveSpeed = 0f;
            GameManager.Instance.isGameStarted = false;
            GameManager.Instance.SetScore();
        }
        
    }

}

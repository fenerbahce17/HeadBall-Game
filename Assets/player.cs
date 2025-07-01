
using UnityEngine;
using UnityEngine.UIElements;

public class player : MonoBehaviour
{
    public GameObject ball;
    private Rigidbody2D rb;
    public float moveSpeed = 5;
    public bool isGround;
    private Rigidbody2D ballRb;
    [HideInInspector]
    public bool isMovingRight = false;
    [HideInInspector]
    public bool isMovingLeft = false;






    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballRb = ball.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isMovingRight)
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        if (isMovingLeft)
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;








        // Movement controls
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            //   rb.velocity=Vector2.right*moveSpeed;
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            shoot();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            //  rb.velocity=Vector2.left*moveSpeed;

        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (transform.position.y > -1.5)
            {

                isGround = false;
            }

            if (isGround)
            {
                jump();
            }
        }
    }

    void jump()
    {
        if (isGround)
        {
            rb.AddForce(Vector2.up * 5000, ForceMode2D.Impulse);

            isGround = false;
        }
    }

    void FixedUpdate()
    {


        Transform objectTransform = this.transform;

        objectTransform.eulerAngles = new Vector3(objectTransform.eulerAngles.x, objectTransform.eulerAngles.y, 0f);


    }
    private float timer = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("ball"))
        {
            



            Vector2 direction = collision.transform.position - transform.position;
            direction.Normalize();


            ballRb.AddForce(direction * 3, ForceMode2D.Impulse);

            // rb.constraints= RigidbodyConstraints2D.FreezePositionX;











        }





    }


/// KLAVYE İÇİN SHOOT
/// </summary>
    public bool canShoot = false;
    void shoot()
    {

        if (canShoot)
        {

            ballRb.AddForce(new Vector2(1, 1 * Time.deltaTime), ForceMode2D.Impulse);


        }






    }
//BUTTON CONTROLS

    public void StartMoveRight()
    {
        isMovingRight = true;
    }
    public void StopMoveRight()
    {
        isMovingRight = false;
    }
    public void StartMoveLeft()
    {
        isMovingLeft = true;
    }
    public void StopMoveLeft()
    {
        isMovingLeft = false;
    }









    public void MoveRight()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
    }

    public void MoveLeft()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
    }

    public void Jump()
    {
        if (isGround)
        {
            rb.AddForce(Vector2.up * 5000, ForceMode2D.Impulse);
            isGround = false;
        }
    }

public void Shoot()
{
    if (canShoot)
    {
        ballRb.velocity = Vector2.zero; // varsa eski hareketi sıfırla
        ballRb.AddForce(new Vector2(15f, 8f), ForceMode2D.Impulse);
        Debug.Log("MOBİL ŞUT ATILDI");
    }
}




}



    
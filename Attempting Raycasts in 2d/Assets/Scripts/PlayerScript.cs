using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject rightStart;
    public GameObject leftStart;
    public float range = 100f;
    public Rigidbody2D rb;
    public LayerMask hitLayerMask;
    public int moveSpeed;

    private bool _doShootRight;
    private bool _doShootLeft;

    // Start is called before the first frame update
    void Start()
    {
        // APK: you made rb public and configurable in the Editor. so we don't override the Editor selection... 
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        _doShootRight = false;
    }

    private void Update()
    {
        // APK: Never check for input in FixedUpdate.
        // Use GetKey instead of GetKeyDown to for holding the key down.
        _doShootRight = Input.GetKey(KeyCode.RightArrow);
        _doShootLeft = Input.GetKey(KeyCode.LeftArrow);

        // APK: Render ray as long as key is down.
        // Can only see this in the Game view if Gizmos are turned on.
        if (_doShootRight)
        {
            Debug.DrawRay(rightStart.transform.position, rightStart.transform.TransformDirection(Vector2.right) * 100f, Color.red);
        }

        if (_doShootLeft)
        {
            Debug.DrawRay(leftStart.transform.position, leftStart.transform.TransformDirection(Vector2.left) * 100f, Color.red);
        }

        if (Input.GetKey(KeyCode.D)) 
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
    }


    //Everything below is meant to shoot a raycast to the right when the player presses right, and then debug what the raycast hit.
    //The raycast only shoots for a split second after every few button presses, and each time it states that it hits the player.
    //If you're able to tell me what is wrong, that would be very much appreciated.
    void FixedUpdate()
    {
        if (_doShootRight)
        {
            ShootRight();
        }

        if (_doShootLeft)
        {
            ShootLeft();
        }
    }

    void ShootRight()
    {
        RaycastHit2D hit = Physics2D.Raycast(rightStart.transform.position,
            rightStart.transform.TransformDirection(Vector2.right),
            100f,
            hitLayerMask); // APK: only objects in these layers count as hit.

        /*
            APK

            1. Create Player layer and assign to Player parent/child objects.
            2. Create a Platform layer and assign to Platform parent/child objects.
            3. Edit this scripts hitLayerMask var in the Editor. You can select one or more layers.

        */


        if (hit)
        {
            Debug.Log($"Ray hit: {hit.collider.name}");
        }

    }

    void ShootLeft()
    {
        RaycastHit2D hit = Physics2D.Raycast(leftStart.transform.position,
            leftStart.transform.TransformDirection(Vector2.left),
            100f,
            hitLayerMask); // APK: only objects in these layers count as hit.

        /*
            APK

            1. Create Player layer and assign to Player parent/child objects.
            2. Create a Platform layer and assign to Platform parent/child objects.
            3. Edit this scripts hitLayerMask var in the Editor. You can select one or more layers.

        */


        if (hit)
        {
            Debug.Log($"Ray hit: {hit.collider.name}");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the player collides with an Obstacle, then the whole scene resets
        if (collision.gameObject.tag == "Obstacle")
        {

            SceneManager.LoadScene("SampleScene");
        }
    }

}


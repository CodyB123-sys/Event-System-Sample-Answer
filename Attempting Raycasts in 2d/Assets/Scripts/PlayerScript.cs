
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject start;
    public float range = 100f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    //Everything below is meant to shoot a raycast to the right when the player presses right, and then debug what the raycast hit.
    //The raycast only shoots for a split second after every few button presses, and each time it states that it hits the player.
    //If you're able to tell me what is wrong, that would be very much appreciated.
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShootRight();
        }
    }

    void ShootRight()
    {
        Debug.DrawRay(start.transform.position, start.transform.TransformDirection(Vector2.right) * 100f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(start.transform.position, start.transform.TransformDirection(Vector2.right), 100f);

        if (hit)
        {
            Debug.Log(hit.collider.name);
        }

    }
}

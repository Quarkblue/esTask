using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class objectController : MonoBehaviour
{

    [Tooltip("The amount of delay in animation for the object")]
    [SerializeField]
    float animDelay = 0f;


    bool isMoving = false;

    [Tooltip("The animation curve for the object")]
    [SerializeField]
    AnimationCurve curve;

    [Tooltip("The offset for the object to move up and down between")]
    [SerializeField]
    float dOffset, uOffset;

    [SerializeField]
    GameObject BlastAnimPrefab;


    void Start()
    {
        StartCoroutine(AnimStart(animDelay));

        // determing a random delay for the animation
        animDelay = Random.Range(0.5f, 2f);

        // Adding animation curve which moves the gems and the platforms
        // To increase the speed of the animation, decrease the time of the curve and vice versa
        curve.MoveKey(0, new Keyframe(0, transform.position.y - dOffset));
        curve.MoveKey(1, new Keyframe(1,transform.position.y + uOffset));

    }

    private void Update()
    {
        move();

    }

    // Function to move the object
    private void move()
    {
        if (isMoving)
        {
            // Animation logic for gems and platforms
            transform.position = new Vector3(transform.position.x, curve.Evaluate((Time.time % curve.length - animDelay)), transform.position.z);

        }
    }


    // Starting the animation with a delay
    IEnumerator AnimStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMoving = true;
    }

    // Destroying the object when clicked
    void OnMouseDown()
    {
        Instantiate(BlastAnimPrefab, transform.position, Quaternion.identity);
        GameManager.instance.DestroyGem(gameObject);
        Destroy(gameObject);
    }

}

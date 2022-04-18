using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hippo : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 5;
    [SerializeField] LevelController _levelController;

    Vector2 _startPosition;
    Rigidbody2D _rigidBody2D;
    SpriteRenderer _spriteRenderer;

    public bool IsDragging { get; private set; }

    void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _rigidBody2D.position;
        _rigidBody2D.isKinematic = true;
        _levelController = GameObject.Find("LevelController").GetComponent<LevelController>();
    }

    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
        IsDragging = true;
        _levelController.attempts -= 1;
    }

    void OnMouseUp()
    {
        Vector2 currentPosition = _rigidBody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _rigidBody2D.isKinematic = false;
        _rigidBody2D.AddForce(direction * _launchForce);

        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        _spriteRenderer.color = Color.white;
        IsDragging = false;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }

        if (desiredPosition.x > _startPosition.x)
        {
            desiredPosition.x = _startPosition.x;
        }

        _rigidBody2D.position = desiredPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }

    IEnumerator ResetAfterDelay()
    {

        yield return new WaitForSeconds(3);
        _rigidBody2D.position = _startPosition;
        _rigidBody2D.isKinematic = true;
        _rigidBody2D.velocity = Vector2.zero;
    }
}

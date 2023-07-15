using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dash : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f; // [SerializeField] делает private поля видимыми в инспекторе
    [SerializeField] private float _dashSpeed;
    [SerializeField] private AnimationCurve _dashSpeedCurve;
    [SerializeField] private float _dashTime = 0.5f;

    private Rigidbody2D _rb;
    private bool _isDashing;
    public int Impulse = 5000; //

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>(); // Если получаете компонент через GetComponent, то делайте RequireComponent(typeof(ТипКомпонента))
    }

    private void Update()
    {
        var directionX = Input.GetAxis("Horizontal");
        var directionY = Input.GetAxis("Vertical");
        var moveDirection = new Vector2(directionX, directionY);

        Move(moveDirection, _movementSpeed);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash(moveDirection * Impulse));
        }

    }

    private void Move(Vector2 direction, float speed)
    {
        if (direction == Vector2.zero) return;
        if (_isDashing) return;

        ApplyVelocity(direction, speed);
    }

    private IEnumerator Dash(Vector2 direction)
    {
        if (direction == Vector2.zero) yield break;
        if (_isDashing) yield break;

        _isDashing = true;

        var elapsedTime = 0f;
        while (elapsedTime < _dashTime)
        {
            var velocityMultiplier = _dashSpeed * _dashSpeedCurve.Evaluate(elapsedTime);

            ApplyVelocity(direction, velocityMultiplier);

            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        _isDashing = false;
        yield break;
    }

    private void ApplyVelocity(Vector2 desiredVelocity, float multiplier) // Дублирующийся код всегда выносить в отдельный метод
    {
        var velocity = _rb.velocity;

        //velocity.y = desiredVelocity.y == 0 ? velocity.y : desiredVelocity.y * multiplier;// чтобы не ломать физику, скорость по Y будет изменяться только если это нужно
        velocity.x = desiredVelocity.x * multiplier;
        velocity.y = desiredVelocity.y * multiplier;

        _rb.velocity = velocity;
    }

}
using System;
using UnityEngine;

public class ActiveBubble
{
    private readonly float _radius;
    private readonly float _gravity;

    private Vector2 _position;
    private Vector2 _speed;

    public event Action<Vector2> PositionChanged;

    public ActiveBubble(float radius, float gravity)
    {
        _radius = radius;
        _gravity = gravity;
    }

    public ActiveBubble(ActiveBubble activeBubble)
    {
        _radius = activeBubble.Radius;
        _gravity = activeBubble.Gravity;
        _position = activeBubble.Position;
        _speed = activeBubble.Direction;
    }

    public float Radius => _radius;
    public float Gravity => _gravity;
    public Vector2 Position => _position;
    public Vector2 Direction => _speed;

    public void SetPosition(Vector2 newPos)
    {
        _position = newPos;
        PositionChanged?.Invoke(newPos);
    }

    public void SetSpeed(Vector2 direction, float speed)
    {
        _speed = speed * direction;
    }

    public void Update(float deltaTime)
    {
        _position += _speed * deltaTime;
        _speed += _gravity * deltaTime * Vector2.down;
    }

    public void CollideWith(Wall wall)
    {
        _speed.x *= -1f;
        _position.x = wall.X - Mathf.Sign(wall.X) * _radius;
    }
}
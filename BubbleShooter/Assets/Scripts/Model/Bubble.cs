using System;
using UnityEngine;

public class Bubble
{
    private Vector2 _position;
    private Vector2 _direction;

    public event Action<Vector2> PositionChanged;

    public Vector2 Position => _position;
    public Vector2 Direction => _direction;

    public Bubble(Bubble bubble)
    {
        _position = bubble.Position;
        _direction = bubble.Direction;
    }

    public void SetPosition(Vector2 newPos)
    {
        _position = newPos;
        PositionChanged?.Invoke(newPos);
    }

    public void SetDirection(Vector2 newDir)
    {
        _direction = newDir;
    }
}
using System;
using UnityEngine;

public enum SlingState
{
    Aiming,
    Firing,
}

public class Sling
{
    private readonly float _fullForceDistance;
    private readonly float _force;

    private float _rotation;
    private SlingState _state;
    private Vector2 _position;
    private Vector2 _direction;
    private ActiveBubble _activeBubble;

    public event Action<Vector2> DirectionChanged;

    public Sling(float force)
    {
        _force = force;
        _fullForceDistance = 1.5f;
        _state = SlingState.Aiming;
        _position = new(0f, -2f);
        _direction = Vector2.up;
        _activeBubble = null;
    }

    public SlingState State => _state;
    public Vector2 Position => _position;
    public Vector2 Direction => _direction;
    public float Rotation => _rotation;

    public void LoadBubble(ActiveBubble activeBubble)
    {
        _activeBubble = activeBubble;
        _activeBubble.SetPosition(_position - _direction);
    }

    public void Update(Vector2 mousePos)
    {
        _direction = _position - mousePos;
        DirectionChanged?.Invoke(_direction);

        _rotation = Vector2.SignedAngle(Vector2.up, _direction);

        if (_activeBubble != null)
        {
            float speed = Mathf.Min(_direction.magnitude, _fullForceDistance);
            Vector2 pull = -speed * _direction.normalized;
            _activeBubble.SetPosition(_position + pull);
            _activeBubble.SetSpeed(_direction.normalized, speed * _force);
        }
    }
}
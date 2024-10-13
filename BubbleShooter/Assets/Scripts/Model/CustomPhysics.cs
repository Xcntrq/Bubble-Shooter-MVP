public class CustomPhysics
{
    private Wall[] _walls;

    public void AddWalls(Wall[] walls)
    {
        _walls = walls;
    }

    public void CheckCollisions(ActiveBubble activeBubble)
    {
        foreach (Wall wall in _walls)
        {
            float leftBound = activeBubble.Position.x - activeBubble.Radius;
            float rightBound = activeBubble.Position.x + activeBubble.Radius;
            if (((wall.X < 0f) && (wall.X > leftBound)) || ((wall.X > 0f) && (wall.X < rightBound)))
            {
                activeBubble.CollideWith(wall);
            }
        }
    }
}
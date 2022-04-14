using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Direction2D
{
    public static List<Vector2Int> cardinalDirectionsList = new List<Vector2Int>
    {
        new Vector2Int(0, -1),
        new Vector2Int(0, 1)
    };

    public static Vector2Int GetRandomCardinalDirection()
    {
        return cardinalDirectionsList[Random.Range(0, cardinalDirectionsList.Count)];
    }
    
    public static HashSet<Vector2Int> RandomWalk(Vector2Int startPsition, int walkLenght)
    {
        HashSet<Vector2Int> path = new HashSet<Vector2Int>();

        path.Add(startPsition);
        var previousPosition = startPsition;

        for (int i = 0; i < walkLenght; i++)
        {
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }

        return path;
    }
}

using System.Collections.Generic;
using UnityEngine;

// The FlyweightFactory manages and provides Flyweight instances.
// It ensures that shared Flyweights are reused instead of creating duplicates.
public class FlyweightFactory
{
    // Dictionary to store and manage Flyweight instances based on a unique key.
    private Dictionary<string, BoxFlyweight> flyweights = new Dictionary<string, BoxFlyweight>();

    // Method to retrieve a Flyweight. If it doesn't exist, create and store a new one.
    public BoxFlyweight GetFlyweight(Vector3 size, Color color)
    {
        // Create a unique key based on size and color to identify Flyweights.
        string key = $"{size}-{color}";

        // Check if a Flyweight with the generated key already exists.
        if (!flyweights.ContainsKey(key))
        {
            // If not, create a new Flyweight and add it to the dictionary.
            flyweights[key] = new BoxFlyweight(size, color);
        }

        // Return the existing or newly created Flyweight.
        return flyweights[key];
    }
}
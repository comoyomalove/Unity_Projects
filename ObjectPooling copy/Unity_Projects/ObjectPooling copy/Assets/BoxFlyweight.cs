using UnityEngine;

// The BoxFlyweight class holds the shared intrinsic attributes for boxes.
// These attributes are shared among multiple Box instances to save memory.
public class BoxFlyweight
{
    // The size of the box. This is shared among boxes using the same Flyweight.
    public Vector3 Size { get; private set; }

    // The color of the box. This is shared among boxes using the same Flyweight.
    public Color Color { get; private set; }

    // Constructor to initialize the Flyweight with size and color.
    public BoxFlyweight(Vector3 size, Color color)
    {
        Size = size;
        Color = color;
    }
}
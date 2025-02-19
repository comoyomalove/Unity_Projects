using UnityEngine;

// The Box class represents a box in the game that bullets can interact with.
// It utilizes the Flyweight pattern to share common attributes like size and color.
public class Box : MonoBehaviour
{
    // Reference to the shared Flyweight containing intrinsic properties.
    private BoxFlyweight flyweight;

    // The unique position of this box in the game world.
    public Vector3 Position { get; set; }

    // Method to initialize the box with a Flyweight and its position.
    public void Initialize(BoxFlyweight flyweight, Vector3 position)
    {
        this.flyweight = flyweight;      // Assign the shared Flyweight.
        this.Position = position;        // Set the unique position.
        ApplyFlyweight();                // Apply the shared attributes to the box.
    }

    // Applies the shared Flyweight attributes to the box's transform and appearance.
    private void ApplyFlyweight()
    {
        transform.position = Position;                           // Set the box's position in the scene.
        transform.localScale = flyweight.Size;                   // Set the box's size based on Flyweight.
        GetComponent<Renderer>().material.color = flyweight.Color; // Set the box's color based on Flyweight.
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialization logic can be placed here if needed.
    }

    // Update is called once per frame
    void Update()
    {
        // Per-frame logic can be placed here if needed.
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The BoxManager class is responsible for creating and managing multiple Box instances in the game.
// It utilizes the Flyweight pattern to optimize memory usage by sharing common attributes among boxes.
public class BoxManager : MonoBehaviour
{
    // Reference to the Box prefab that will be instantiated in the scene.
    public GameObject boxPrefab;

    // The total number of boxes to create in the game.
    public int numberOfBoxes = 50;

    // Defines the area within which boxes will be randomly spawned.
    public Vector3 spawnArea = new Vector3(50, 0, 50);

    // Instance of FlyweightFactory to manage and provide shared BoxFlyweight objects.
    private FlyweightFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the FlyweightFactory.
        factory = new FlyweightFactory();

        // Loop to create the specified number of boxes.
        for (int i = 0; i < numberOfBoxes; i++)
        {
            // Generate a random position within the defined spawn area.
            Vector3 position = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x), // Random X position
                0,                                       // Y position fixed at 0
                Random.Range(-spawnArea.z, spawnArea.z)  // Random Z position
            );

            // Retrieve a shared BoxFlyweight with specific size and color.
            // In this case, all boxes have the same size (1,1,1) and color (white).
            BoxFlyweight flyweight = factory.GetFlyweight(new Vector3(1, 1, 1), Color.white);

            // Instantiate a new Box from the Box prefab at the generated position with no rotation.
            GameObject boxObj = Instantiate(boxPrefab, position, Quaternion.identity);

            // Get the Box component from the instantiated GameObject.
            Box box = boxObj.GetComponent<Box>();

            // Initialize the Box with the shared Flyweight and its unique position.
            box.Initialize(flyweight, position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Currently empty. Can be used for dynamic updates if needed in the future.
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour {
    public GameObject obstacle;
    public int obstaclesPerSide;
    public float distanceBetweenObstacles;
    public float heightVariation;   // The distance the obstacles can vary

    private Stack<GameObject> spawnedObjects;

    private void Start() {
        spawnedObjects = new Stack<GameObject>();

        // Initial generation of obstacles
        GenerateObstacles();
    }

    public void GenerateObstacles() {
        for (int i = 1; i < obstaclesPerSide + 1; i++) {
            /* Calculate the position by setting the x to a constant distance
               away from other obstacles, and randomize the y position. */
            Vector2 position = new Vector2(distanceBetweenObstacles * i,
                Random.Range(-heightVariation, heightVariation));

            // Spawn the object at the position
            spawnedObjects.Push(Object.Instantiate(obstacle, position, 
                Quaternion.identity));

            // Calculate the position for obstacle on the other side
            position = new Vector2(distanceBetweenObstacles * -i, 
                Random.Range(-heightVariation, heightVariation));
                
            // Spawn the object at the position
            spawnedObjects.Push(Object.Instantiate(obstacle, position, 
                Quaternion.identity));
        }
    }

    public void DestroyObstacles() {
        int objectCount = spawnedObjects.Count;

        // Loop through the number of spawned objects
        for (int i = 0; i < objectCount; i++) {
            // Remove the object from the stack and destroy it
            Object.Destroy(spawnedObjects.Pop().gameObject);
        }
    }
}

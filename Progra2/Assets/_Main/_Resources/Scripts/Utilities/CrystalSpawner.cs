using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    // The prefab for the crystal item
    public GameObject crystalPrefab;

    // The binary tree that will store the crystal items
    private NewABB.BinaryTree crystalTree;

    private void Start()
    {
        // Create a new binary tree
        crystalTree = new NewABB.BinaryTree();

        // Spawn 10 crystal items
        for (var i = 0; i < 8; i++)
        {
            // Generate a random position for the crystal
            var position = new Vector3(Random.Range(-10, 8), 0, Random.Range(-10, 8));

            // Instantiate the crystal prefab at the random position
            var crystal = Instantiate(crystalPrefab, position, Quaternion.identity);

            // Add the crystal to the binary tree
            //crystalTree.Add(crystal);
        }
    }
}
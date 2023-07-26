using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtil : ScriptableObject
{
    private static System.Random random = new System.Random();

    public static void DeactivateAll(List<GameObject> gameObjects)
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }

    public static void ActivateRandom(List<GameObject> gameObjects)
    {
        int randomIndex = random.Next(0, gameObjects.Count);
        gameObjects[randomIndex].SetActive(true);
    }

    public static void GetRandomElement(List<GameObject> gameObjects, GameObject excludedGameObject)
    {
        //int randomIndex = random.Next(0, gameObjects.Count);
        // TODO
    }
}

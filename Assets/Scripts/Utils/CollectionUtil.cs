using System.Collections.Generic;
using UnityEngine;

public class CollectionUtil : ScriptableObject
{
    private static readonly System.Random random = new System.Random();

    /// <summary>
    /// Returns a randomly selected element from a list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="elements"></param>
    /// <returns>A randomly selected element from a list or the default value of T if the list is null or empty</returns>
    public static T GetRandomElement<T>(List<T> elements)
    {
        if (elements == null || elements.Count <= 0)
        {
            Debug.Log(string.Format("CollectionUtil.GetRandomElement [elements: {0}] unexpectedly null or empty.", elements));
            return default;
        }

        int randomIndex = random.Next(0, elements.Count);
        return elements[randomIndex];
    }

    /// <summary>
    /// Returns a randomly selected element from a list while excluding all excludeElements from consideration
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="elements"></param>
    /// <param name="excludeElements"></param>
    /// <returns>A randomly selected element from a list or the default value of T if the list is null or empty</returns>
    public static T GetRandomElementExcluding<T>(List<T> elements, IReadOnlyCollection<T> excludeElements)
    {
        if (elements == null || elements.Count <= 0)
        {
            Debug.Log(string.Format("CollectionUtil.GetRandomElementExcluding [elements: {0}, excludeElements: {1}] unexpectedly null or empty.", elements, excludeElements));
            return default;
        }

        List<T> reducedList = new List<T>(elements.ToArray());
        if (excludeElements != null)
        {
            foreach (T excludedElement in excludeElements)
            {
                bool isRemoved = reducedList.Remove(excludedElement);
                if (!isRemoved)
                    Debug.Log(string.Format("CollectionUtil.GetRandomElementExcluding [elements: {0}, excludeElements: {1}] [element: {2}] was not successfully removed from list.", elements, excludeElements, excludedElement));
            }
        }

        if (reducedList.Count <= 0)
        {
            Debug.Log(string.Format("CollectionUtil.GetRandomElementExcluding [elements: {0}, excludeElements: {1}] reducedList unexpectedly empty.", elements, excludeElements));
            return default;
        }

        int randomIndex = random.Next(0, reducedList.Count);
        return reducedList[randomIndex];
    }

}

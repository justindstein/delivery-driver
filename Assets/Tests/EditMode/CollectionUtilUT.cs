using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CollectionUtilUT
{
    private static readonly List<string> NULL_LIST = null;
    private static readonly List<string> EMPTY_LIST = new List<string>();

    private List<string> elements;
    private List<string> excludeElements;
    private List<string> excludeElementsFull;

    [SetUp]
    public void Setup()
    {
        this.elements = new List<string>() {
            "0"
            , "1"
            , "2"
            , "3"
            , "4"
        };

        this.excludeElements = new List<string>() {
            "0"
            , "4"
        };

        this.excludeElementsFull = new List<string>() {
            "0"
            , "1"
            , "2"
            , "3"
            , "4"
        };
    }

    // Not necesssary, for educational purposes
    [TearDown]
    public void TearDown()
    {
        this.elements = null;
        this.excludeElements = null;
        this.excludeElementsFull = null;
    }

    [Test]
    public void GetRandomElement_ElementsNull()
    {
        string randomElement = CollectionUtil.GetRandomElement(CollectionUtilUT.NULL_LIST);
        Assert.IsNull(randomElement);
    }

    [Test]
    public void GetRandomElement_ElementsEmpty()
    {
        string randomElement = CollectionUtil.GetRandomElement(CollectionUtilUT.EMPTY_LIST);
        Assert.IsNull(randomElement);
    }

    [Test]
    public void GetRandomElement_Elements()
    {
        string randomElement = CollectionUtil.GetRandomElement(this.elements);

        Assert.NotNull(randomElement);
        Assert.Contains(randomElement, this.elements);

        Assert.IsTrue("0".Equals(elements[0]));
        Assert.IsTrue("1".Equals(elements[1]));
        Assert.IsTrue("2".Equals(elements[2]));
        Assert.IsTrue("3".Equals(elements[3]));
        Assert.IsTrue("4".Equals(elements[4]));
    }

    [Test]
    public void GetRandomElementExcluding_ElementsNull_ExcludeElementsNull()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(CollectionUtilUT.NULL_LIST, CollectionUtilUT.NULL_LIST);
        Assert.IsNull(randomElement);
    }

    [Test]
    public void GetRandomElementExcluding_ElementsEmpty_ExcludeElementsNull()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(CollectionUtilUT.EMPTY_LIST, CollectionUtilUT.NULL_LIST);
        Assert.IsNull(randomElement);
    }

    [Test]
    public void GetRandomElementExcluding_Elements_ExcludeElementsNull()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(this.elements, CollectionUtilUT.NULL_LIST);

        Assert.NotNull(randomElement);
        Assert.Contains(randomElement, this.elements);

        Assert.IsTrue("0".Equals(elements[0]));
        Assert.IsTrue("1".Equals(elements[1]));
        Assert.IsTrue("2".Equals(elements[2]));
        Assert.IsTrue("3".Equals(elements[3]));
        Assert.IsTrue("4".Equals(elements[4]));
    }

    [Test]
    public void GetRandomElementExcluding_ElementsNull_ExcludeElementsEmpty()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(CollectionUtilUT.NULL_LIST, CollectionUtilUT.EMPTY_LIST);
        Assert.IsNull(randomElement);
    }

    [Test]
    public void GetRandomElementExcluding_ElementsEmpty_ExcludeElementsEmpty()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(CollectionUtilUT.EMPTY_LIST, CollectionUtilUT.EMPTY_LIST);
        Assert.IsNull(randomElement);
    }

    [Test]
    public void GetRandomElementExcluding_Elements_ExcludeElementsEmpty()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(this.elements, CollectionUtilUT.EMPTY_LIST);

        Assert.NotNull(randomElement);
        Assert.Contains(randomElement, this.elements);

        Assert.IsTrue("0".Equals(elements[0]));
        Assert.IsTrue("1".Equals(elements[1]));
        Assert.IsTrue("2".Equals(elements[2]));
        Assert.IsTrue("3".Equals(elements[3]));
        Assert.IsTrue("4".Equals(elements[4]));
    }

    [Test]
    public void GetRandomElementExcluding_ElementsNull_ExcludeElements()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(CollectionUtilUT.NULL_LIST, this.excludeElements);
        Assert.IsNull(randomElement);
    }

    [Test]
    public void GetRandomElementExcluding_ElementsEmpty_ExcludeElements()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(CollectionUtilUT.EMPTY_LIST, this.excludeElements);
        Assert.IsNull(randomElement);
    }

    [Test]
    public void GetRandomElementExcluding_Elements_ExcludeElements()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(this.elements, this.excludeElements);

        Assert.NotNull(randomElement);
        Assert.Contains(randomElement, this.elements);
        Assert.False(this.excludeElements.Contains(randomElement));

        Assert.IsTrue("0".Equals(elements[0]));
        Assert.IsTrue("1".Equals(elements[1]));
        Assert.IsTrue("2".Equals(elements[2]));
        Assert.IsTrue("3".Equals(elements[3]));
        Assert.IsTrue("4".Equals(elements[4]));
    }

    [Test]
    public void GetRandomElementExcluding_Elements_ExcludeElementsFull()
    {
        string randomElement = CollectionUtil.GetRandomElementExcluding(this.elements, this.excludeElementsFull);

        Assert.Null(randomElement);
    }
}

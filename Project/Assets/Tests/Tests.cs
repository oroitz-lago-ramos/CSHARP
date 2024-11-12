using System.Collections;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UIElements;

public class Tests
{
    [Test]
    public void StatsCopyFunc()
    {
        Stats stats1 = new Stats();
        stats1.health = 100;
        Stats stats2 = new Stats();
        Assert.AreNotEqual(stats1, stats2);
        stats1.CopyTo(stats2);
        Assert.AreEqual(stats1.health, stats2.health);
        Assert.AreEqual(stats1.mana, stats2.mana);
        Assert.AreEqual(stats1.defense, stats2.defense);
        Assert.AreEqual(stats1.accuracy, stats2.accuracy);
        Assert.AreEqual(stats1.attack, stats2.attack);
        Assert.AreEqual(stats1.speed, stats2.speed);
        Assert.AreEqual(stats1.criticalRate, stats2.criticalRate);
    }

    [Test]
    public void ViewControllerToggles()
    {
        Assert.AreEqual(ViewController.currentMenu, ViewType.None);
    }

    [Test]
    public void EntityLevelUP()
    {
        Entity entity = new Entity();
        Assert.AreEqual(entity.level, 0);
        entity.experience = 100000;
        entity.CheckLevel();
        Assert.AreNotEqual(entity.level, 0);
    }
}

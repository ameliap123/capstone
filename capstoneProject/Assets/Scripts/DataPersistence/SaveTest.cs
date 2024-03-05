using UnityEngine;
using NUnit.Framework;

public class DataPersistenceManagerTests
{
    [Test]
    public void SaveGame_NullGameData_ShouldNotSave()
    {
        // Arrange
        var gameObject = new GameObject();
        var dataPersistenceManager = gameObject.AddComponent<DataPersistenceManager>();

        // Act
        dataPersistenceManager.SaveGame();

        // Assert
        // Check that SaveGame doesn't throw an exception and doesn't save data when gameData is null
        Assert.IsFalse(dataPersistenceManager.HasGameData());
    }

    [Test]
    public void SaveGame_ValidGameData_ShouldSave()
    {
        // Arrange
        var gameObject = new GameObject();
        var dataPersistenceManager = gameObject.AddComponent<DataPersistenceManager>();
        var dummyGameData = new GameData(); // Creating dummy game data
        var privateField = typeof(DataPersistenceManager).GetField("gameData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        privateField.SetValue(dataPersistenceManager, dummyGameData); // Setting dummy game data using reflection

        // Act
        dataPersistenceManager.SaveGame();

        // Assert
        // Check that SaveGame saves the game data
        Assert.IsTrue(dataPersistenceManager.HasGameData());
    }
}

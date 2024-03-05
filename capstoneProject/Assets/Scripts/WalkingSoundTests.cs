using NUnit.Framework;
using UnityEngine;

public class WalkingSoundTests
{
    private WalkingSound walkingSound;
    private bool warningLogged = false;

    [SetUp]
    public void Setup()
    {
        GameObject testObject = new GameObject();
        walkingSound = testObject.AddComponent<WalkingSound>();
        Application.logMessageReceived += HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (type == LogType.Warning && logString.Contains("No footstep sounds assigned!"))
        {
            warningLogged = true;
        }
    }

    [Test]
    public void WalkingSound_PlayFootstepSound_NoFootstepSoundsAssigned_LogsWarning()
    {
        // Arrange
        walkingSound.footstepSounds = new AudioClip[0];

        // Act
        walkingSound.PlayFootstepSound();

        // Assert
        Assert.IsTrue(warningLogged);
    }

    [Test]
    public void WalkingSound_PlayFootstepSound_FootstepSoundsAssigned_PlaysFootstepSound()
    {
        // Arrange
        AudioClip testClip = AudioClip.Create("TestClip", 100, 2, 44100, false);
        walkingSound.footstepSounds = new AudioClip[] { testClip };

        // Act
        walkingSound.PlayFootstepSound();

        // Assert
        AudioSource[] audioSources = walkingSound.GetComponents<AudioSource>();
        Assert.AreEqual(1, audioSources.Length);
        Assert.AreEqual(testClip, audioSources[0].clip);
    }
}


using NUnit.Framework;
using UnityEngine;

public class MovementTest
{
    private PlayerDummy dummy;

	[SetUp]

	public void Setup()
    {
        GameObject testObject = new GameObject();
        dummy = testObject.AddComponent<PlayerMovement>();
    }

    [Test]
    public void Movement_NoInput_ShouldHaveNoMovement()
    {
        Vector2 position1 (
			dummy.xdir;
			dummy.ydir;
		)
    }
}

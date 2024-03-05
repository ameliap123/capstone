using NUnit.Framework;
using UnityEngine;

public class MovementTest
{
	private PlayerMovement dummy;
	
	[SetUp]
	public void Setup()
	{
		GameObject testObject = new GameObject();
		dummy = testObject.AddComponent<PlayerMovement>();
	}

	[Test]
	public void Movement_NoInput_ShouldHaveNoMovement()
	{
		//Arange
		Vector2 position1 (
			dummy.xdir,
			dummy.ydir
		);
		Vector2 position2 (
			dummy.xdir,
			dummy.ydir
		);
		
		//Act

		//Assert
		Assert.AreEqual(position1, position2);
	}

	[Test]
	public void Movement_Input_ShouldHaveMovement()
	{	
		//Arrange
		Vector2 position1 (
			dummy.xdir,
			dummy.ydir
		);
		
		//Act
		Input.ResetInputAxes();
		dummy.FixedUpdate();
		
		Vector2 position2 (
			dummy.xdir,
			dummy.ydir
		);

		//Assert
		Assert.NotEqual(position1, position2);
	}
}

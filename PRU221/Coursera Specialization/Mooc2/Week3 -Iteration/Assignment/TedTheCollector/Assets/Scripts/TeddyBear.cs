using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A collecting teddy bear
/// </summary>
public class TeddyBear : MonoBehaviour
{
	#region Fields

	const float ImpulseForceMagnitude = 2.0f;

	bool collecting = false;
	GameObject targetPickup = null;

	// saved for efficiency
	Rigidbody2D rb2d;
	TedTheCollector tedTheCollector;

	#endregion

	#region Methods

	/// <summary>
	/// Start is called before the first frame update
	/// </summary>
	void Start()
	{
		// center teddy bear in screen
		Vector3 position = Vector3.zero;

		// save references for efficiency
		rb2d = GetComponent<Rigidbody2D>();
		tedTheCollector = Camera.main.GetComponent<TedTheCollector>();
	}

	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button
	/// over the collider
	/// </summary>
	void OnMouseDown()
	{
		// ignore mouse clicks if already collecting
		if (!collecting)
		{
			collecting = true;
			GoToNextPickup();
		}
	}

	/// <summary>
	/// Called when another object is within a trigger collider
	/// attached to this object
	/// </summary>
	/// <param name="other"></param>
	void OnTriggerStay2D(Collider2D other)
	{
		// only respond if the collision is with the target pickup
		if (other.gameObject == targetPickup)
		{
			// remove collected pickup from game and go to the next one
			tedTheCollector.RemovePickup(targetPickup);
			rb2d.velocity = Vector2.zero;
			GoToNextPickup();
		}
	}

	/// <summary>
	/// Updates the pickup currently targeted for collection.
	/// If the provided pickup is closer than the currently
	/// targeted pickup, the provided pickup is set as the
	/// new target. Otherwise, the targeted pickup isn't
	/// changed.
	/// </summary>
	/// <param name="pickup">pickup</param>
	public void UpdateTarget(GameObject pickup)
	{
		if (targetPickup == null)
		{
			SetTarget(pickup);
		}
		else
		{
			float targetDistance = GetDistance(targetPickup);
			if (GetDistance(pickup) < targetDistance)
			{
				SetTarget(pickup);
			}
		}
	}

	/// <summary>
	/// Sets the target pickup to the provided pickup
	/// </summary>
	/// <param name="pickup">Pickup.</param>
	void SetTarget(GameObject pickup)
	{
		targetPickup = pickup;
		if (collecting)
		{
			GoToTargetPickup();
		}
	}

	/// <summary>
	/// Starts the teddy bear moving toward the next pickup
	/// </summary>
	void GoToNextPickup()
	{
		// calculate direction to target pickup and start moving toward it
		targetPickup = GetClosestPickup();
		if (targetPickup != null)
		{
			GoToTargetPickup();
		}
		else
		{
			collecting = false;
		}
	}

	/// <summary>
	/// Starts the teddy bear moving toward the target pickup
	/// </summary>
	void GoToTargetPickup()
	{
		// calculate direction to target pickup and start moving toward it
		Vector2 direction = new Vector2(
			targetPickup.transform.position.x - transform.position.x,
			targetPickup.transform.position.y - transform.position.y);
		direction.Normalize();
		rb2d.velocity = Vector2.zero;
		rb2d.AddForce(direction * ImpulseForceMagnitude,
			ForceMode2D.Impulse);
	}

	/// <summary>
	/// Gets the pickup in the scene that's closest to the teddy bear
	/// If there are no pickups in the scene, returns null
	/// </summary>
	/// <returns>closest pickup</returns>
	GameObject GetClosestPickup()
	{
		// initial setup
		List<GameObject> pickups = tedTheCollector.Pickups;
		GameObject closestPickup;
		float closestDistance;
		if (pickups.Count == 0)
		{
			return null;
		}
		else
		{
			closestPickup = pickups[0];
			closestDistance = GetDistance(closestPickup);
		}

		// find and return closest pickup
		foreach (GameObject pickup in pickups)
		{
			float distance = GetDistance(pickup);
			if (distance < closestDistance)
			{
				closestPickup = pickup;
				closestDistance = distance;
			}
		}
		return closestPickup;
	}

	/// <summary>
	/// Gets the distance between the teddy bear and the 
	/// provided pickup
	/// </summary>
	/// <returns>distance</returns>
	/// <param name="pickup">pickup</param>
	float GetDistance(GameObject pickup)
	{
		return Vector3.Distance(transform.position, pickup.transform.position);
	}

	#endregion
}

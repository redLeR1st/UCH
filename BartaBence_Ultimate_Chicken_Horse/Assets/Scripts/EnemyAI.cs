using UnityEngine;
using System.Collections;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{

	// What to chase?
	public Transform target;

	// How many times each second we will update our path
	public float updateRate = 2f;

	// Caching
	private Seeker seeker;
	private Rigidbody2D rb;

	//The calculated path
	public Path path;

	//The AI's speed per second
	public float speed = 300f;
	public ForceMode2D fMode;

	[HideInInspector]
	public bool pathIsEnded = false;

	// The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;

	// The waypoint we are currently moving towards
	private int currentWaypoint = 0;

	public bool logging = true;

	public float distanceToPlayMusic;

	AudioManager audioManager;

	void Start()
	{

		if(AudioManager.instance != null)
		{
			audioManager = AudioManager.instance;
		}

		seeker = GetComponent<Seeker>();
		rb = GetComponent<Rigidbody2D>();

		if (target == null)
		{
			Debug.LogError("No Player found? PANIC!");
			return;
		}

		// Start a new path to the target position, return the result to the OnPathComplete method
		seeker.StartPath(transform.position, target.position, OnPathComplete);

		StartCoroutine(UpdatePath());
	}

	IEnumerator UpdatePath()
	{
		if (target == null)
		{
			//TODO: Insert a player search here.
			yield return false;
		}

		// Start a new path to the target position, return the result to the OnPathComplete method
		seeker.StartPath(transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds(1f / updateRate);
		StartCoroutine(UpdatePath());
	}

	public void OnPathComplete(Path p)
	{
		if (logging)
			Debug.Log("We got a path. Did it have an error? " + p.error);

		if (!p.error)
		{
			path = p;
			currentWaypoint = 0;
		}
	}

	void FixedUpdate()
	{
		float dis = Vector3.Distance(gameObject.transform.position, target.transform.position);

		//print("Dis: " + dis);

		if (dis < distanceToPlayMusic)
		{
			float ratio = dis/distanceToPlayMusic;
			float pitch = 1.5f / ratio;
			float volume = 1 - ratio;

			//print("PLAY: " + pitch + "><" + volume + "ratio: " + ratio);
			audioManager.PlaySound("Monstergetclose", pitch, volume);
			
		}


		if (target == null)
		{
			//TODO: Insert a player search here.
			return;
		}

		//TODO: Always look at player?

		if (path == null)
			return;

		if (currentWaypoint >= path.vectorPath.Count)
		{
			if (pathIsEnded)
				return;

			if (logging)
				Debug.Log("End of path reached.");

			pathIsEnded = true;
			return;
		}
		pathIsEnded = false;

		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;

		//Move the AI
		rb.AddForce(dir, fMode);

		float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
		if (dist < nextWaypointDistance)
		{
			currentWaypoint++;
			return;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

	public enum FollowType{
		MoveTowards,
		Lerp
	}

	public FollowType Type = FollowType.MoveTowards;
	public PathOfIceBall path;
	public float speed = 1;
	public float maxDistanceToGoal = .1f;

	private IEnumerator<Transform> _currentPoint;


	public void Start()
	{
		if (path == null) {
			Debug.LogError ("Path can't be null", gameObject);
			return;
		}

		_currentPoint = path.GetPathsEnumerator ();
		_currentPoint.MoveNext ();

		if (_currentPoint.Current == null) {
			return;
		}

		transform.position = _currentPoint.Current.position;
	}

	public void Update(){
		if (_currentPoint == null || _currentPoint.Current == null) {
			return;
		}

		if (Type == FollowType.MoveTowards) {
			transform.position = Vector3.MoveTowards (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
		} else if(Type == FollowType.Lerp){
			transform.position = Vector3.Lerp (transform.position, _currentPoint.Current.position, Time.deltaTime * speed);

		}

		var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;
		if (distanceSquared < maxDistanceToGoal * maxDistanceToGoal)
			_currentPoint.MoveNext ();
	}
}

namespace Game.Hero
{
	using System.Collections;
	using System.Collections.Generic;
	using UniRx;
	using UnityEngine;
	using UnityEngine.AI;
	using Zenject;

	[RequireComponent(typeof(NavMeshAgent))]
	public sealed class HeroMotion : MonoBehaviour
	{
		[SerializeField] List<Waypoint> _waypoints;
		
		[Inject] readonly NavMeshAgent _agent;

		int _current;
		
		void Start()
		{
			StartCoroutine( Motion_Cor() );
		}

		public BoolReactiveProperty IsMoving { get; } = new();
		
		IEnumerator Motion_Cor()
		{
			while ( _current < _waypoints.Count )
			{
				Waypoint waypoint = _waypoints[_current];

				_agent.SetDestination( waypoint.transform.position );
				
				IsMoving.Value = true;
				Debug.Log( $"IsMoving: {IsMoving.Value}" );
				
				while ( !DestinationReached() )
					yield return null;

				IsMoving.Value = false;
				Debug.Log( $"IsMoving: {IsMoving.Value}" );

				//yield return new WaitUntil( () => waypoint.IsAllEnemyKilled );
				yield return new WaitForSeconds( 3f );

				_current ++;
			}

			Debug.Log( "Finish!" );
		}
		

		bool DestinationReached() => !_agent.pathPending && _agent.remainingDistance < float.Epsilon;
	}
}
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
		[SerializeField] List<Waypoint>		_waypoints;
		
		[Inject] readonly NavMeshAgent		_agent;
		[Inject] readonly GameplayConfig	_gameplayConfig;

		int _current;
		
		void Start()
		{
			_agent.speed = _gameplayConfig.HeroSpeed;
			
			StartCoroutine( Motion_Cor() );
		}

		
		public BoolReactiveProperty IsMoving				{ get; } = new();
		
		public ReactiveCommand OnAllWaypointsReached		{ get; } = new();
		
		
		IEnumerator Motion_Cor()
		{
			while ( _current < _waypoints.Count )
			{
				Waypoint waypoint = _waypoints[_current];

				_agent.SetDestination( waypoint.transform.position );
				
				IsMoving.Value = true;
				
				while ( !DestinationReached() )
					yield return null;

				IsMoving.Value = false;

				yield return waypoint.OnAllEnemyKilled.First().ToYieldInstruction();

				_current ++;
			}

			OnAllWaypointsReached.Execute();
		}
		

		bool DestinationReached() => !_agent.pathPending && _agent.remainingDistance < float.Epsilon;
	}
}
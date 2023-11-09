namespace Game
{
	using System;
	using Game.Enemy;
	using System.Collections.Generic;
	using System.Linq;
	using UniRx;
	using UnityEngine;

	public sealed class Waypoint : MonoBehaviour
	{
		[SerializeField] List<EnemyFacade> _enemies;

		public IObservable<Unit> OnAllEnemyKilled { get; private set; }

		void Start()
		{
			// On All Enemy Killed
			OnAllEnemyKilled = _enemies
				.Select( e => e.IsDead )
				.CombineLatestValuesAreAllTrue()
				.Where( v => v )
				.AsUnitObservable();
		}
	}
}
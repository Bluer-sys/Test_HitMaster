namespace Game
{
	using System.Collections.Generic;
	using UniRx;
	using UnityEngine;

	public sealed class Waypoint : MonoBehaviour
	{
		[SerializeField] List<Enemy.Enemy> _enemies;

		public ReactiveCommand OnAllEnemyKilled { get; } = new();
		public bool IsAllEnemyKilled => _enemies.TrueForAll( e => e.IsDead );
	}
}
namespace Game.Enemy
{
	using UnityEngine;
	using Zenject;

	public sealed class Enemy : MonoBehaviour
	{
		[Inject] readonly EnemyHealth _enemyHealth;

		public bool IsDead => _enemyHealth.IsDead;
	}
}
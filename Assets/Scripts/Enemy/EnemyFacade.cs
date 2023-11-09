namespace Game.Enemy
{
	using UniRx;
	using UnityEngine;
	using Zenject;

	public sealed class EnemyFacade : MonoBehaviour
	{
		[Inject] readonly EnemyHealth _enemyHealth;

		public BoolReactiveProperty IsDead	=> _enemyHealth.IsDead;
	}
}
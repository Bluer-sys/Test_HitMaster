namespace Game.Enemy
{
	using UniRx;
	using UnityEngine;

	public sealed class EnemyHealth : MonoBehaviour, IDamagable
	{
		[SerializeField] int _health;
		
		int _curHealth;

		void Start()
		{
			_curHealth = _health;
		}

		public BoolReactiveProperty IsDead { get; } = new();

#region IDamagable

		public void TakeDamage(int damage)
		{
			_curHealth = Mathf.Clamp( _curHealth - damage, 0, _health );

			if ( _curHealth == 0 )
				IsDead.Value = true;
		}

#endregion

		[ContextMenu("Kill")]
		void SetDead_Debug()
		{
			IsDead.Value = true;
		}
	}
}
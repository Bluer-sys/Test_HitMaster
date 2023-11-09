namespace Game.Enemy
{
	using UniRx;
	using UnityEngine;

	public sealed class EnemyHealth : MonoBehaviour, IDamagable
	{
		[SerializeField] int _health;
		
		void Start()
		{
			Current.Value = _health;
		}

		
#region Properties

		public BoolReactiveProperty IsDead		{ get; } = new();
		
		public FloatReactiveProperty Current	{ get; } = new();
		
		public float Max						=> _health;

#endregion
		
		
#region IDamagable

		public void TakeDamage(int damage)
		{
			Current.Value = Mathf.Clamp( Current.Value - damage, 0, _health );

			if ( Current.Value == 0 )
				IsDead.Value = true;
		}

#endregion
	}
}
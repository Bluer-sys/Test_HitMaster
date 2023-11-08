namespace Game
{
	using Game.Enemy;
	using UnityEngine;
	using Zenject;

	public sealed class Bullet : MonoBehaviour
	{
		[Inject] GameplayConfig _gameplayConfig;
		
		void Update()
		{
			float delta = Time.deltaTime * _gameplayConfig.BulletSpeed;

			Raycast( delta )?.TakeDamage( _gameplayConfig.BulletDamage );
			
			Move( delta );
		}

		void Move(float delta)			=> transform.position += transform.up * delta;

		IDamagable Raycast(float delta)
		{
			Vector3 origin	= transform.position;
			Vector3 dir		= transform.up;

			Physics.Raycast( 
				origin, 
				dir,
				out RaycastHit hitInfo, 
				delta, 
				LayerMask.GetMask( "Damagable" ) 
			);

			return hitInfo.collider.GetComponentInChildren<IDamagable>();
		}
		
		public class Pool : MonoMemoryPool<Vector3, Quaternion, Bullet>
		{
			protected override void Reinitialize(Vector3 pos, Quaternion rot, Bullet bullet)
			{
				bullet.transform.position = pos;
				bullet.transform.rotation = rot;
			}
		}
	}
}
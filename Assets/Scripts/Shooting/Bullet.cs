namespace Game.Shooting
{
	using System.Collections;
	using Game.Enemy;
	using UnityEngine;
	using Zenject;

	public sealed class Bullet : MonoBehaviour
	{
		[Inject] GameplayConfig _gameplayConfig;
		[Inject] Bullet.Pool	_bulletPool;

		Coroutine _lifetimeCor;
		
		Vector3 Direction	=> transform.forward;

		void OnEnable()		=> _lifetimeCor = StartCoroutine( Lifetime_Cor() );
		void OnDisable()	=> StopCoroutine( _lifetimeCor );

		void Update()
		{
			float deltaPos	= _gameplayConfig.BulletSpeed * Time.deltaTime;
			Collider col	= Raycast( deltaPos );

			if ( col != null )
			{
				IDamagable damagable = col.GetComponentInParent<IDamagable>();

				damagable?.TakeDamage( _gameplayConfig.BulletDamage );

				_bulletPool.Despawn( this );
			}

			Move( deltaPos );
		}

		void Move(float delta)			=> transform.position += Direction * delta;

		Collider Raycast(float delta)
		{
			Vector3 origin	= transform.position;
			Vector3 dir		= Direction;

			Physics.Raycast( 
				origin, 
				dir,
				out RaycastHit hitInfo, 
				delta, 
				LayerMask.GetMask( "Default" ) 
			);

			return hitInfo.collider;
		}

		IEnumerator Lifetime_Cor()
		{
			yield return new WaitForSeconds( _gameplayConfig.BulletLifetime );

			_bulletPool.Despawn( this );
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
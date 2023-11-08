namespace Game.Enemy
{
	using System.Collections.Generic;
	using Game.Hero;
	using UniRx;
	using UnityEngine;
	using Zenject;

	public class EnemyRagdollController : MonoBehaviour
	{
		[SerializeField] List<Rigidbody>	_ragdoll;
		[SerializeField] Rigidbody			_mainBone;

		[Inject] EnemyHealth	_enemyHealth;
		[Inject] IHeroFacade	_heroFacade;
		[Inject] GameplayConfig _gameplayConfig;
		
		void Start()
		{
			// On Dead
			_enemyHealth.IsDead
				.Where( v => v )
				.Subscribe( _ => ThrowRagdoll() )
				.AddTo( this );
		}

		void ThrowRagdoll()
		{
			_ragdoll.ForEach( rb => rb.isKinematic = false );

			Vector3 forceDir	= ( transform.position - _heroFacade.Transform.position ).normalized;
			Vector3 force		= forceDir * _gameplayConfig.EnemyThrowForce;
			
			_mainBone.AddForce( force, ForceMode.VelocityChange );
		}
	}
}
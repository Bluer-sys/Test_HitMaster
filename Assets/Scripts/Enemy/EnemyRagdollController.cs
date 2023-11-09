namespace Game.Enemy
{
	using System.Collections.Generic;
	using System.Linq;
	using Game.Hero;
	using UniRx;
	using UnityEngine;
	using Zenject;

	public sealed class EnemyRagdollController : MonoBehaviour
	{
		[SerializeField] Rigidbody			_mainBone;

		[Inject] readonly Animator			_animator;
		[Inject] readonly EnemyHealth		_enemyHealth;
		[Inject] readonly IHeroFacade		_heroFacade;
		[Inject] readonly GameplayConfig	_gameplayConfig;

		List<Rigidbody>	_ragdoll;

		void Start()
		{
			_ragdoll = GetComponentsInChildren<Rigidbody>().ToList();
			
			EnableRagdoll( false );

			// On Dead
			_enemyHealth.IsDead
				.Where( v => v )
				.Subscribe( _ => ThrowRagdoll() )
				.AddTo( this );
		}

		void ThrowRagdoll()
		{
			EnableRagdoll( true );

			Vector3 forceDir	= ( transform.position - _heroFacade.Transform.position ).normalized;
			Vector3 force		= forceDir * _gameplayConfig.EnemyThrowForce;
			
			_mainBone.AddForce( force, ForceMode.VelocityChange );
		}

		void EnableRagdoll(bool state)
		{
			_ragdoll.ForEach( rb => rb.isKinematic = !state );
			_animator.enabled = !state;
		}
	}
}
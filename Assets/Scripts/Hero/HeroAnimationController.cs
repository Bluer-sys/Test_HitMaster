namespace Game.Hero
{
	using System;
	using UniRx;
	using UnityEngine;
	using Zenject;

	public sealed class HeroAnimationController : IInitializable, IDisposable
	{
		static readonly int IsRun = Animator.StringToHash( "IsRun" );
		
		[Inject] readonly Animator		_animator;
		[Inject] readonly HeroMotion	_heroMotion;

		readonly CompositeDisposable	_lifetimeDisposables = new();
		
		public void Initialize()
		{
			// Toggle Run State
			_heroMotion.IsMoving
				.Subscribe( v => _animator.SetBool( IsRun, v ) )
				.AddTo( _lifetimeDisposables );
		}

		public void Dispose()	=> _lifetimeDisposables.Dispose();
	}
}
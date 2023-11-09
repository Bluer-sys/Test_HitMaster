namespace Game.Shooting
{
	using System;
	using Game.Hero;
	using Input;
	using UniRx;
	using UnityEngine;
	using Zenject;

	public sealed class BulletSpawner : IInitializable, IDisposable
	{
		[Inject] readonly Bullet.Pool	_bulletPool;
		[Inject] readonly IPlayerInput	_input;
		[Inject] readonly IHeroFacade	_heroFacade;

		readonly CompositeDisposable	_lifetimeDisposables = new();

		Camera _camera;

		public void Initialize()
		{
			_camera = Camera.main;

			// Bullet Spawn
			_input.OnScreenClick
				.Skip( 1 )								// Skip First Tap For Start Game (Temp Dirty Solution)
				.Where( _ => !_heroFacade.IsMoving )
				.Subscribe( Spawn )
				.AddTo( _lifetimeDisposables );
		}

		void Spawn(Vector3 scrPos)
		{
			Ray ray		= _camera.ScreenPointToRay( scrPos );
			
			_bulletPool.Spawn( _camera.transform.position, Quaternion.LookRotation( ray.direction ) );
		}

		public void Dispose() => _lifetimeDisposables.Dispose();
	}
}
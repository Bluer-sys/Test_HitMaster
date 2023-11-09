namespace Game.Shooting
{
	using System;
	using Input;
	using UniRx;
	using UnityEngine;
	using Zenject;

	public sealed class BulletSpawner : IInitializable, IDisposable
	{
		[Inject] Bullet.Pool	_bulletPool;
		[Inject] IPlayerInput	_input;

		readonly CompositeDisposable _lifetimeDisposables = new();

		Camera _camera;

		public void Initialize()
		{
			_camera = Camera.main;

			// Bullet Spawn
			_input.OnScreenClick
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
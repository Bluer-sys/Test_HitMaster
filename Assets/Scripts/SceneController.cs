namespace Game
{
	using System;
	using Game.Hero;
	using UniRx;
	using UnityEngine.SceneManagement;
	using Zenject;

	public sealed class SceneController : IInitializable, IDisposable
	{
		[Inject] readonly IHeroFacade		_heroFacade;
		[Inject] readonly GameplayConfig	_gameplayConfig;

		readonly CompositeDisposable		_lifetimeDisposables = new();


		public void Initialize()
		{
			// On Finished
			_heroFacade.OnAllWaypointReached
				.Delay( TimeSpan.FromSeconds( _gameplayConfig.RestartSceneDelay ) )
				.Subscribe( _ => RestartScene() )
				.AddTo( _lifetimeDisposables );
		}

		public void Dispose() => _lifetimeDisposables.Dispose();

		void RestartScene() => SceneManager.LoadScene( SceneManager.GetActiveScene().name );
	}
}
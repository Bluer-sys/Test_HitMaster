namespace Game.UI
{
	using System;
	using Game.Enemy;
	using UniRx;
	using Zenject;

	public class UiEnemyController : IInitializable, IDisposable
	{
		[Inject] readonly IUiEnemyView	_view;
		[Inject] readonly EnemyHealth	_enemyHealth;

		readonly CompositeDisposable _lifetimeDisposables = new();


		public void Initialize()
		{
			// On Health Change
			_enemyHealth.Current
				.Subscribe( c => _view.SetHealthBarFill( c / _enemyHealth.Max ) )
				.AddTo( _lifetimeDisposables );
		}

		public void Dispose() => _lifetimeDisposables.Dispose();
	}
}
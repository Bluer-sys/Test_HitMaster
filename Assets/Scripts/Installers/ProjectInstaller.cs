namespace Game.Installers
{
	using UnityEngine;
	using Zenject;

	public sealed class ProjectInstaller : MonoInstaller
	{
		[SerializeField] GameplayConfig _gameplayConfig;
		
		public override void InstallBindings()
		{
			// GameplayConfig
			Container.BindInstance( _gameplayConfig );
		}
	}
}
namespace Game.Input
{
	using UniRx;
	using UnityEngine;
	using Zenject;

	public interface IPlayerInput
	{
		ReactiveCommand<Vector3> OnScreenClick { get; }
	}

	public sealed class PlayerInput : ITickable, IPlayerInput
	{
		public void Tick()
		{
			if ( Input.GetMouseButtonDown( 0 ) )
				OnScreenClick.Execute( Input.mousePosition );
		}

#region IPlayerInput

		public ReactiveCommand<Vector3> OnScreenClick { get; } = new();

#endregion
	}
}
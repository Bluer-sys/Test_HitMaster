namespace Game
{
	using Game.Shooting;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Configs/Gameplay", fileName = "Gameplay", order = 0)]
	public sealed class GameplayConfig : ScriptableObject
	{
		[Header( "Scene" )] 
		public float	RestartSceneDelay;
		
		[Header( "Hero" )] 
		public float	HeroSpeed;
			
		[Header( "Enemy" )] 
		public float	EnemyThrowForce;
		
		[Header( "Bullet" )] 
		public Bullet	BulletPrefab;
		public float	BulletSpeed;
		public int		BulletDamage;
		public float	BulletLifetime;
	}
}
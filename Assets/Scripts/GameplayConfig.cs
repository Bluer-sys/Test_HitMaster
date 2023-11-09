namespace Game
{
	using Game.Shooting;
	using UnityEngine;

	[CreateAssetMenu(menuName = "Configs/Gameplay", fileName = "Gameplay", order = 0)]
	public class GameplayConfig : ScriptableObject
	{
		
		[Header( "Bullet" )] 
		public Bullet	BulletPrefab;
		public float	BulletSpeed;
		public int		BulletDamage;
		public float	BulletLifetime;

		[Header( "Enemy" )] 
		public float	EnemyThrowForce;

	}
}
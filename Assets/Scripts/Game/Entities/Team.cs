namespace Tartaros.Entities
{
	public enum Team
	{
		Neutral = 0,
		Player,
		Enemy,
	}

	public static class TeamExtensions
	{
		public static Team GetOpponent(this Team team)
		{
			switch (team)
			{
				case Team.Player:
					return Team.Enemy;

				case Team.Enemy:
					return Team.Player;

				default:
					throw new System.NotImplementedException();
			}
		}
	}
}

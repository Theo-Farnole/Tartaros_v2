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

		public static bool HasOpponent(this Team team)
		{
			switch (team)
			{
				case Team.Player:
				case Team.Enemy:
					return true;

				case Team.Neutral:
					return false;

				default:
					throw new System.NotImplementedException();
			}
		}
	}
}

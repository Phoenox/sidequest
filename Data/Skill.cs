namespace SideQuest.Data;

public record Skill(string Name)
{
	public Guid Id { get; init; } = Guid.NewGuid();
	public int Xp { get; init; }
	public int Level { get; init; }
	public IEnumerable<Quest> Quests { get; init; } = [];
}

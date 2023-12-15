namespace SideQuest.Data;

public record Quest(string Name, int Xp)
{
	public Guid Id { get; init; } = Guid.NewGuid();
}

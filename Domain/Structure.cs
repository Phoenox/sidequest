namespace SideQuest.Domain;

public static class Structure
{
	public static Skill AddQuest(Skill skill, Quest quest)
		=> skill with { Quests = skill.Quests.Append(quest) };
	
	public static Skill RemoveQuest(Skill skill, Quest quest)
		=> skill with { Quests = skill.Quests.Where(q => q.Id != quest.Id) };
}

namespace SideQuest.Domain;

using Data;

public static class Progression
{
	public static Skill MarkQuestAsDone(Skill skill, Quest quest) {
		var updatedSkill = skill with {Xp = skill.Xp + quest.Xp};
		if (updatedSkill.Xp >= 100)
			updatedSkill = updatedSkill with {
					Level = skill.Level + 1,
					Xp = updatedSkill.Xp - 100,
			};
		return updatedSkill;
	}
}

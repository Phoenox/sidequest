namespace SideQuest.Providers;

using Data;

public static class SkillProvider
{
	private static readonly List<Skill> Skills = [
			new Skill("Reading") {
					Quests = [
							new Quest("Read a book", 10),
							new Quest("Read another book", 10),
					],
			},
			new Skill("Fighting") {
					Quests = [
							new Quest("Fight a monster", 10),
							new Quest("Fight another monster", 10),
					],
			},
			new Skill("Magic") {
					Quests = [
							new Quest("Cast a spell", 10),
							new Quest("Cast another spell", 10),
					],
			},
	];

	public static IEnumerable<Skill> GetSkills()
		=> Skills.AsReadOnly();

	public static Skill GetSkill(Guid id)
		=> Skills.First(s => s.Id == id);
	
	public static void UpdateSkill(Skill skill) {
		var index = Skills.FindIndex(s => s.Id == skill.Id);
		Skills[index] = skill;
	}
}

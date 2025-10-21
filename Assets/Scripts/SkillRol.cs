using UnityEngine;

public class SkillRol : MonoBehaviour
{
    public NotificationScript noti;
    public Skill skill;
    public Stat stat;
    private bool f;
    private bool d;
    public void Roll()
    {
        if (f)
        {
            noti.Roll(100, skill.current +stat.current, skill.statName + " roll, with favor", 'f');
        }
        else if (d)
        {
            noti.Roll(100, skill.current + stat.current, skill.statName + " roll, with disfavor", 'd');
        }
        else {
            noti.Roll(100, skill.current + stat.current, skill.statName + " roll", 'n');
        }
    }
}

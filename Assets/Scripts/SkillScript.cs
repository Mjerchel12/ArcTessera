using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour
{
    internal byte baseScore;
    internal byte score;
    public string skill;
    internal bool expertise;
    public bool isAtt;
    public CharacterBar characterB;
    internal Character character;
    public TextMeshProUGUI scoreText;
    public GameObject E;
    public Button plus;
    public Button minus;

    public TextMeshProUGUI skillPoints;
    public TextMeshProUGUI exPoints;
    public TextMeshProUGUI attPoints;

    public bool CanAdd()
    {
        return (isAtt && score < baseScore + 10 && int.Parse(attPoints.text)>0)||
               (expertise && score < baseScore + 20 && int.Parse(exPoints.text) > 0)||
               ((!expertise && !isAtt) && score < baseScore + 10 && int.Parse(skillPoints.text) > 0);
    }
    public bool CanRemove()
    {
        return ((isAtt && score > baseScore) ||
               (expertise && score > baseScore -2) ||
               ((!expertise && !isAtt) && score > baseScore))&&score>=0;
    }

    public void Add() {
        if(CanAdd()) {
            if (isAtt) { 
                byte x = byte.Parse(attPoints.text);
                x--;
                attPoints.text=x.ToString();
            };
            if (expertise)
            {
                byte x = byte.Parse(exPoints.text);
                x--;
                exPoints.text = x.ToString();
            };
            if (!isAtt&&!expertise)
            {
                byte x = byte.Parse(skillPoints.text);
                x--;
                skillPoints.text = x.ToString();
            };
            score++;
            Debug.Log("add");
            Change();
            Debug.Log("add2");
        }
        Debug.Log("add3");
        if (!CanAdd())
        {
            Debug.Log("can't add");
            plus.enabled = false;
        }
        if (CanRemove())
        {
            Debug.Log("can remove");
            minus.enabled = true;
        }
    }
    public void Remove() {
        if (CanRemove())
        {
            if (isAtt)
            {
                byte x = byte.Parse(attPoints.text);
                x++;
                attPoints.text = x.ToString();
            };
            if (expertise)
            {
                byte x = byte.Parse(exPoints.text);
                x++;
                exPoints.text = x.ToString();
            };
            if (!isAtt && !expertise)
            {
                byte x = byte.Parse(skillPoints.text);
                x++;
                skillPoints.text = x.ToString();
            };
            score--;
            Change();
        }
        Debug.Log("remove");
        if (!CanRemove())
        {
            Debug.Log("can't remove");
            minus.enabled = false;
        }
        if (CanAdd())
        {
            Debug.Log("can add");
            plus.enabled = true;
        }
    }

    private void Start()
    {
        character = characterB.character;
        score = baseScore;
        scoreText.text = score.ToString();
        if (!expertise) { 
            E.SetActive(false);
        }
        if (!CanRemove())
        {
            minus.enabled = false;
        }
        if (!CanAdd())
        {
            plus.enabled = false;
        }
    }
    private void Change()
    {
        if (score < baseScore) { scoreText.color = new Color(255, 0, 0); }
        else if (score > baseScore) { scoreText.color = new Color(0, 255, 0); }
        else { scoreText.color = new Color(255, 255, 255); }
        scoreText.text = score.ToString();
        if (skill == "body")
        {
            character.att.body.value = score;
            character.att.body.current = score;
        }
        else if (skill == "athletics")
        {
            character.att.athletics.value = score;
            character.att.athletics.current = score;
        }
        else if (skill == "strength")
        {
            character.att.strength.value = score;
            character.att.strength.current = score;
        }
        else if (skill == "vigor")
        {
            character.att.vigor.value = score;
            character.att.vigor.current = score;
        }
        else if (skill == "resistance")
        {
            character.att.resistance.value = score;
            character.att.resistance.current = score;
        }
        else if (skill == "endurance")
        {
            character.att.endurance.value = score;
            character.att.endurance.current = score;
        }
        else if (skill == "fortitude")
        {
            character.att.fortitude.value = score;
            character.att.fortitude.current = score;
        }
        else if (skill == "melee")
        {
            character.att.melee.value = score;
            character.att.melee.current = score;
        }
        else if (skill == "grace")
        {
            character.att.body.value = score;
            character.att.body.current = score;
        }
        else if (skill == "acrobatics")
        {
            character.att.acrobatics.value = score;
            character.att.acrobatics.current = score;
        }
        else if (skill == "accuracy")
        {
            character.att.marksmanship.value = score;
            character.att.marksmanship.current = score;
        }
        else if (skill == "stealth")
        {
            character.att.stealth.value = score;
            character.att.stealth.current = score;
        }
        else if (skill == "dexterity")
        {
            character.att.dexterity.value = score;
            character.att.dexterity.current = score;
        }
        else if (skill == "martial")
        {
            character.att.martial.value = score;
            character.att.martial.current = score;
        }
        else if (skill == "fencing")
        {
            character.att.fencing.value = score;
            character.att.fencing.current = score;
        }
        else if (skill == "reactions")
        {
            character.att.react.value = score;
            character.att.react.current = score;
        }
        else if (skill == "riding")
        {
            character.att.riding.value = score;
            character.att.riding.current = score;
        }
        else if (skill == "mind")
        {
            character.att.mind.value = score;
            character.att.mind.current = score;
        }
        else if (skill == "arcana")
        {
            character.att.arcana.value = score;
            character.att.arcana.current = score;
        }
        else if (skill == "nature")
        {
            character.att.nature.value = score;
            character.att.nature.current = score;
        }
        else if (skill == "religion")
        {
            character.att.religion.value = score;
            character.att.religion.current = score;
        }
        else if (skill == "survival")
        {
            character.att.survival.value = score;
            character.att.survival.current = score;
        }
        else if (skill == "lore")
        {
            character.att.lore.value = score;
            character.att.lore.current = score;
        }
        else if (skill == "investigation")
        {
            character.att.investigation.value = score;
            character.att.investigation.current = score;
        }
        else if (skill == "tactics")
        {
            character.att.tactics.value = score;
            character.att.tactics.current = score;
        }
        else if (skill == "soul")
        {
            character.att.soul.value = score;
            character.att.soul.current = score;
        }
        else if (skill == "willpower")
        {
            character.att.willpower.value = score;
            character.att.willpower.current = score;
        }
        else if (skill == "intuition")
        {
            character.att.intuition.value = score;
            character.att.intuition.current = score;
        }
        else if (skill == "alertness")
        {
            character.att.alertness.value = score;
            character.att.alertness.current = score;
        }
        else if (skill == "spellcraft")
        {
            character.att.spellcraft.value = score;
            character.att.spellcraft.current = score;
        }
        else if (skill == "fervor")
        {
            character.att.fervor.value = score;
            character.att.fervor.current = score;
        }
        else if (skill == "trade")
        {
            character.att.trade.value = score;
            character.att.trade.current = score;
        }
        else if (skill == "medicine")
        {
            character.att.medicine.value = score;
            character.att.medicine.current = score;
        }
        else if (skill == "alchemy")
        {
            character.att.alchemy.value = score;
            character.att.alchemy.current = score;
        }
        else if (skill == "forgery")
        {
            character.att.forgery.value = score;
            character.att.forgery.current = score;
        }
        else if (skill == "craft")
        {
            character.att.craft.value = score;
            character.att.craft.current = score;
        }
        else if (skill == "burglary")
        {
            character.att.burglary.value = score;
            character.att.burglary.current = score;
        }
        else if (skill == "performances")
        {
            character.att.performance.value = score;
            character.att.performance.current = score;
        }
        else if (skill == "personality")
        {
            character.att.personality.value = score;
            character.att.personality.current = score;
        }
        else if (skill == "courtship")
        {
            character.att.courtship.value = score;
            character.att.courtship.current = score;
        }
        else if (skill == "manipulation")
        {
            character.att.manipulation.value = score;
            character.att.manipulation.current = score;
        }
        else if (skill == "persuasion")
        {
            character.att.persuasion.value = score;
            character.att.persuasion.current = score;
        }
        else if (skill == "business")
        {
            character.att.business.value = score;
            character.att.business.current = score;
        }
        else if (skill == "intimidation")
        {
            character.att.intimidation.value = score;
            character.att.intimidation.current = score;
        }
    }
}

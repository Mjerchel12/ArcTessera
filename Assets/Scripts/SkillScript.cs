using System;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillScript : MonoBehaviour
{
    public byte baseScore;
    public byte score;
    public string skill;
    public bool expertise;
    public bool isAtt;
    public CharacterBar characterB;
    public Character character;
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
               (expertise && score > baseScore) ||
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
    }
    private void Update()
    {
        if (!expertise)
        {
            E.SetActive(false);
        }
        else
        {
            E.SetActive(true);
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
        Stat stat = (Stat)FieldFinder.FindField(character, skill);
        stat.SetValue(score);
        //if (skill == "body")
        //{
        //    character.body.value = score;
        //    character.body.current = score;
        //}
        //else if (skill == "athletics")
        //{
        //    character.athletics.value = score;
        //    character.athletics.current = score;
        //}
        //else if (skill == "strength")
        //{
        //    character.strength.value = score;
        //    character.strength.current = score;
        //}
        //else if (skill == "vigor")
        //{
        //    character.vigor.value = score;
        //    character.vigor.current = score;
        //}
        //else if (skill == "resistance")
        //{
        //    character.resistance.value = score;
        //    character.resistance.current = score;
        //}
        //else if (skill == "endurance")
        //{
        //    character.endurance.value = score;
        //    character.endurance.current = score;
        //}
        //else if (skill == "fortitude")
        //{
        //    character.fortitude.value = score;
        //    character.fortitude.current = score;
        //}
        //else if (skill == "melee")
        //{
        //    character.melee.value = score;
        //    character.melee.current = score;
        //}
        //else if (skill == "grace")
        //{
        //    character.grace.value = score;
        //    character.grace.current = score;
        //}
        //else if (skill == "acrobatics")
        //{
        //    character.acrobatics.value = score;
        //    character.acrobatics.current = score;
        //}
        //else if (skill == "accuracy")
        //{
        //    character.marksmanship.value = score;
        //    character.marksmanship.current = score;
        //}
        //else if (skill == "stealth")
        //{
        //    character.stealth.value = score;
        //    character.stealth.current = score;
        //}
        //else if (skill == "dexterity")
        //{
        //    character.dexterity.value = score;
        //    character.dexterity.current = score;
        //}
        //else if (skill == "martial")
        //{
        //    character.martial.value = score;
        //    character.martial.current = score;
        //}
        //else if (skill == "fencing")
        //{
        //    character.fencing.value = score;
        //    character.fencing.current = score;
        //}
        //else if (skill == "reactions")
        //{
        //    character.react.value = score;
        //    character.react.current = score;
        //}
        //else if (skill == "riding")
        //{
        //    character.riding.value = score;
        //    character.riding.current = score;
        //}
        //else if (skill == "mind")
        //{
        //    character.mind.value = score;
        //    character.mind.current = score;
        //}
        //else if (skill == "arcana")
        //{
        //    character.arcana.value = score;
        //    character.arcana.current = score;
        //}
        //else if (skill == "nature")
        //{
        //    character.nature.value = score;
        //    character.nature.current = score;
        //}
        //else if (skill == "religion")
        //{
        //    character.religion.value = score;
        //    character.religion.current = score;
        //}
        //else if (skill == "survival")
        //{
        //    character.survival.value = score;
        //    character.survival.current = score;
        //}
        //else if (skill == "lore")
        //{
        //    character.lore.value = score;
        //    character.lore.current = score;
        //}
        //else if (skill == "investigation")
        //{
        //    character.investigation.value = score;
        //    character.investigation.current = score;
        //}
        //else if (skill == "tactics")
        //{
        //    character.tactics.value = score;
        //    character.tactics.current = score;
        //}
        //else if (skill == "soul")
        //{
        //    character.soul.value = score;
        //    character.soul.current = score;
        //}
        //else if (skill == "willpower")
        //{
        //    character.willpower.value = score;
        //    character.willpower.current = score;
        //}
        //else if (skill == "intuition")
        //{
        //    character.intuition.value = score;
        //    character.intuition.current = score;
        //}
        //else if (skill == "alertness")
        //{
        //    character.alertness.value = score;
        //    character.alertness.current = score;
        //}
        //else if (skill == "spellcraft")
        //{
        //    character.spellcraft.value = score;
        //    character.spellcraft.current = score;
        //}
        //else if (skill == "fervor")
        //{
        //    character.fervor.value = score;
        //    character.fervor.current = score;
        //}
        //else if (skill == "trade")
        //{
        //    character.trade.value = score;
        //    character.trade.current = score;
        //}
        //else if (skill == "medicine")
        //{
        //    character.medicine.value = score;
        //    character.medicine.current = score;
        //}
        //else if (skill == "alchemy")
        //{
        //    character.alchemy.value = score;
        //    character.alchemy.current = score;
        //}
        //else if (skill == "forgery")
        //{
        //    character.forgery.value = score;
        //    character.forgery.current = score;
        //}
        //else if (skill == "craft")
        //{
        //    character.craft.value = score;
        //    character.craft.current = score;
        //}
        //else if (skill == "burglary")
        //{
        //    character.burglary.value = score;
        //    character.burglary.current = score;
        //}
        //else if (skill == "performances")
        //{
        //    character.performance.value = score;
        //    character.performance.current = score;
        //}
        //else if (skill == "personality")
        //{
        //    character.personality.value = score;
        //    character.personality.current = score;
        //}
        //else if (skill == "courtship")
        //{
        //    character.courtship.value = score;
        //    character.courtship.current = score;
        //}
        //else if (skill == "manipulation")
        //{
        //    character.manipulation.value = score;
        //    character.manipulation.current = score;
        //}
        //else if (skill == "persuasion")
        //{
        //    character.persuasion.value = score;
        //    character.persuasion.current = score;
        //}
        //else if (skill == "business")
        //{
        //    character.business.value = score;
        //    character.business.current = score;
        //}
        //else if (skill == "intimidation")
        //{
        //    character.intimidation.value = score;
        //    character.intimidation.current = score;
        //}
    }
}

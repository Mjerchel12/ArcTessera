using static Lineage;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Background:CharOption
{
    public byte bodyBonus;
    public byte graceBonus;
    public byte mindBonus;
    public byte soulBonus;
    public byte tradeBonus;
    public byte personalityBonus;
    public SkillBonus skillBonus;
    public string equipmentDesc;
    public List<string> equipment;
}
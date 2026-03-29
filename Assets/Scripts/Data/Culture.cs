using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Culture:CharOption
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
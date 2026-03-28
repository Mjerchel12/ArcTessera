using System;
using UnityEngine;
using static UnityEngine.ParticleSystem;
[Serializable]
public class Focus : Item
{
    public char? utility;
    public char? mind;
    public char? mod;
    public char? summon;
    public char? close;
    public char? projectile;
    public char? blast;
    public char? wave;
    public char? explode;
    public char? sorc;
    public char? bless;
    public char? hex;
    public char? div;
    public char? ilu;
    public char? conj;
    public char? battle;
    public char? psion;
    public char? geo;
    public char? pyro;
    public char? hydro;
    public char? aero;
    public char? necro;
    public char? hemo;
    public char? holy;
    public char? green;
    public char? warp;
    public Focus CopyFocus(byte quant)
    {
        Focus copy = new Focus();
        foreach (var type in types)
        {
            copy.types.Add(type);
        }
        copy.itemName = itemName;
        copy.desc = desc;
        copy.quantity = quant;
        
        copy.utility = utility;
        copy.mind = mind;
        copy.mod = mod;
        copy.summon = summon;
        copy.close = close;
        copy.projectile = projectile;
        copy.blast = blast;
        copy.wave = wave;
        copy.explode = explode;
        copy.sorc = sorc;
        copy.bless = bless;
        copy.hex = hex;
        copy.div = div;
        copy.ilu = ilu;
        copy.conj = conj;
        copy.battle = battle;
        copy.psion = psion;
        copy.geo = geo;
        copy.pyro = pyro;
        copy.hydro = hydro;
        copy.aero = aero;
        copy.necro = necro;
        copy.hemo = hemo;
        copy.holy = holy;
        copy.green = green;
        copy.warp = warp;
        return copy;
    }

    public override string GiveDesc()
    {
        string ret = "";
        foreach (var type in types)
        {
            ret = "<b>" + type + "</b> " + ret;
        }
        if (utility != null)
        {
            ret += "<b>Utility: </b>" + utility + " ";
        }
        if (mind != null)
        {
            ret += "<b>Mind: </b>" + mind + " ";
        }
        if (mod != null)
        {
            ret += "<b>Modification: </b>" + mod + " ";
        }
        if (summon != null)
        {
            ret += "<b>Summoning: </b>" + summon + " ";
        }
        if (close != null)
        {
            ret += "<b>Melee: </b>" + close + " ";
        }
        if (projectile != null)
        {
            ret += "<b>Projectile: </b>" + projectile + " ";
        }
        if (blast != null)
        {
            ret += "<b>Blast: </b>" + blast + " ";
        }
        if (wave != null)
        {
            ret += "<b>Wave: </b>" + wave + " ";
        }
        if (explode != null)
        {
            ret += "<b>Explosion: </b>" + explode + " ";
        }
        if (sorc != null)
        {
            ret += "<b>Sorcery: </b>" + sorc + " ";
        }
        if (bless != null)
        {
            ret += "<b>Blessing: </b>" + bless + " ";
        }
        if (hex != null)
        {
            ret += "<b>Hexing: </b>" + hex + " ";
        }
        if (div != null)
        {
            ret += "<b>Divination: </b>" + div + " ";
        }
        if (ilu != null)
        {
            ret += "<b>Illusion: </b>" + ilu + " ";
        }
        if (conj != null)
        {
            ret += "<b>Conjuration: </b>" + conj + " ";
        }
        if (battle != null)
        {
            ret += "<b>Battle Magic: </b>" + battle + " ";
        }
        if (psion != null)
        {
            ret += "<b>Psionics: </b>" + psion + " ";
        }
        if (geo != null)
        {
            ret += "<b>Geomancy: </b>" + geo + " ";
        }
        if (pyro != null)
        {
            ret += "<b>Pyromancy: </b>" + pyro + " ";
        }
        if (hydro != null)
        {
            ret += "<b>Hydromancy: </b>" + hydro + " ";
        }
        if (aero != null)
        {
            ret += "<b>Aeromancy: </b>" + aero + " ";
        }
        if (necro != null)
        {
            ret += "<b>Necromancy: </b>" + necro + " ";
        }
        if (hemo != null)
        {
            ret += "<b>Hemomancy: </b>" + hemo + " ";
        }
        if (holy != null)
        {
            ret += "<b>Holy Magic: </b>" + holy + " ";
        }
        if (green != null)
        {
            ret += "<b>Green Magic: </b>" + green + " ";
        }
        if (warp != null)
        {
            ret += "<b>Warp Magic: </b>" + warp + " ";
        }
        return ret;
    }
}
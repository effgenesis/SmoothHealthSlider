using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Spells
{
    public enum Type
    {
        Heal,
        Harm
    }

    public static Dictionary<Type, float> _spellsPower = new Dictionary<Type, float>
    {
        {Type.Heal, 10f },
        {Type.Harm, -10f }
    };

    public static float GetPower(Type type)
    {
        return _spellsPower[type];
    }
}

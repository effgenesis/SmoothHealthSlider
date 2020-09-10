using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSlot : MonoBehaviour
{
    [SerializeField] private Spells.Type _spell;
    [SerializeField] public Health Target;

    public void Cast()
    {
        Target.EffectedBySpell(_spell);
    }
}

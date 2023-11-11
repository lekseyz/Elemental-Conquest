using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private MagicSystem ms;
    Dictionary<string, BasicSpell> magics = new Dictionary<string, BasicSpell>();
    public BasicSpell fb;

    private void Start()
    {
        ms = GetComponent<MagicSystem>();

        magics.Add("f", fb);
    }

    private void Update()
    {
        inputHandle();
    }

    void inputHandle()
    {
        if (Input.GetKeyDown(KeyCode.J))
            ms.addElem(MagicSystem.Elements.Fire);

        if (Input.GetKeyDown(KeyCode.K))
            ms.addElem(MagicSystem.Elements.Wind);

        if (Input.GetKeyDown(KeyCode.Space))
            applyAttack();


    }


    void applyAttack()
    {
        //Attack handling
        var comb = ms.getFinalCombination();
        Debug.Log("Attacked: " + comb);

        BasicSpell spell;

        if(magics.TryGetValue(comb, out spell)) {
            spell.activate(this.gameObject);
        }
    }
}

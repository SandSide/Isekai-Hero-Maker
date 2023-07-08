using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Potential{
	Mage,
	Swordsman,
	Priest,
	MartialArtist
}

public enum Trait{
    Brave,
	Coward,
	StrongWill,
	WeakWill,
	Stupid,
	Intelligent
}

public class Quest
{
    public int age;
    public Potential potential;
    public Trait trait;

    public Quest(int age, Potential potential, Trait trait)
    {
        this.age = age;
        this.potential = potential;
        this.trait = trait;
    }
}
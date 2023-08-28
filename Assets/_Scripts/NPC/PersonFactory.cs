using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonFactory : MonoBehaviour
{

    public static Person CreatePerson(int minAge, int maxAge)
    {
        int age = Random.Range(minAge, maxAge + 1);

        var potentials = System.Enum.GetValues(typeof(Potential));
        Potential potential = (Potential)potentials.GetValue(Random.Range(0, potentials.Length));

        var traits = System.Enum.GetValues(typeof(Trait));
        Trait trait = (Trait)traits.GetValue(Random.Range(0, traits.Length));

        Person newPerson = new Person(age, potential, trait);

        return newPerson;
    }
}

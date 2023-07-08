using UnityEngine;

public class TraitEvaluator
{

    public static int Evaluate(Trait requested, Trait recieved)
    {
        if(recieved == requested)
            return 10;
        else if(IsTraitOpposite(requested, recieved))
            return -10;
        else
            return 0;
    }

    public static bool IsTraitOpposite(Trait requested, Trait recieved)
    {
        switch(requested)
        {
            case Trait.Brave:
                return recieved == Trait.Coward;

            case Trait.Coward:
                return recieved == Trait.Brave;

            case Trait.StrongWill:
                return recieved == Trait.WeakWill;
            
            case Trait.WeakWill:
                return recieved == Trait.StrongWill;

            case Trait.Intelligent:
                return recieved == Trait.Stupid;

            case Trait.Stupid:
                return recieved == Trait.Intelligent;
        }

        return false;
    }

}
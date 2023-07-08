public class PotentialEvaluator
{
    public static int Evaluate(Potential requested, Potential recieved)
    {
        if(recieved == requested)
            return 10;
        else if(IsPotentialClose(requested, recieved))
            return 5;
        else
            return -10;
    }

    public static bool IsPotentialClose(Potential requested, Potential recieved)
    {
        switch(requested)
        {
            case Potential.Mage:
                return recieved == Potential.Priest;

            case Potential.Priest:
                return recieved == Potential.Mage;

            case Potential.Swordsman:
                return recieved == Potential.MartialArtist;
            
            case Potential.MartialArtist:
                return recieved == Potential.Swordsman;

        }

        return false;
    }
}
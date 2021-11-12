using System;

namespace Game{
    public interface IPlayer{
        //Tout objet interfacant IPlayer doit retourner un coup, ici représenté par un numéro de colonne.
        public int makeAMove(int columns);
        char Symbol
        {
            get;
            set;
        }
    }
}
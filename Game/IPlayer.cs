using System;

namespace Game{
    public interface IPlayer{
        //Tout objet interfacant IPlayer doit retourner un coup, ici représenté par un numéro de colonne.
        public int makeAMove(Grid grid);
        char Symbol
        {
            get;
            set;
        }
    }
}
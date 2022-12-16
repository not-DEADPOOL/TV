using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Televisore
{
    class TV
    {
        bool stato, muto;
        int volume, canale;
        public TV()
        {
            stato = false;
            volume = 0;
            canale = 1;
            muto = true;
        }
        public TV(bool s, bool m, int v, int c)
        {
            stato = s;
            volume = v;
            canale = c;
            muto = m;
        }

        public void Accendi()
        {
            stato = true;
        }
        public void Impostocanale(int can)
        {
            canale = stato ? can : 1;
        }
        public void canale_next()
        {
            canale += stato ? (canale < 99 ? (canale > -1 ? 1 : 0) : 0) : 0; //0<=Canali<=99
        }
        public void canale_prec()
        {
            canale -= stato ? (canale < 100 ? (canale > 0 ? 1 : 0) : 0) : 0;
        }
        public void Aumenta_vol()
        {
            volume += stato ? (volume < 10 ? (volume > -1 ? 1 : 0) : 0) : 0; // 0<=volume<=10
        }
        public void Aumenta_vol(int volume)
        {
            if (this.volume + volume > 10 && stato)
            {
                do
                {
                    Console.Write("volume error: Valore inserito invalido.\nReinserire volume:");
                    volume = Convert.ToInt32(Console.ReadLine());
                } while (this.volume + volume > 10);
            }
            else if (stato)
            {
                this.volume += volume;
            }
        }
        public void Diminuisci_vol()
        {
            volume -= stato ? (volume < 11 ? (volume > 0 ? 1 : 0) : 0) : 0; // 0<=volume<=10
        }
        public void Diminuisci_vol(int volume)
        {
            if (this.volume - volume < 0 && stato)
            {
                do
                {
                    Console.Write("volume error: Valore inserito invalido.\nReinserire volume:");
                    volume = Convert.ToInt32(Console.ReadLine());
                } while (this.volume - volume < 0);
            }
            else if (stato)
            {
                this.volume -= volume;
            }
        }

        public void Muto()
        {
            if (stato)
                muto = true;
        }
        public string Stampa()
        {
            if (stato)
            {
                return "stato:" + (stato ? "accesa" : "spenta") + " | " + "volume:" + $"{volume}" + " | "  + "canale:" + $"{canale}" + " | " + "muto:" + (muto ? "muted" : "unmuted"); 
            }
            return "";
        }

    }
}

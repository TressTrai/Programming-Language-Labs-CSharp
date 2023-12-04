using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_Labs_CSharp
{
    internal class Money
    {
        private uint rubles;
        private byte kopeeks;

        public uint Rubles
        {
            get { return rubles; }
            set
            {
                if (value < 0)
                    rubles = 0;
                else
                    rubles = value;
            }
        }

        public byte Kopeeks
        {
            get { return kopeeks; }
            set
            {
                if (value < 0)
                    kopeeks = 0;
                else if (value < 100)
                    kopeeks = value;
                else
                    kopeeks = (byte)(value % 100);
                rubles += (uint)(value / 100);
            }
        }

        public Money()
        {
            Rubles = 0;
            Kopeeks = 0;
        }

        public Money(uint rub, byte kop)
        {
            Rubles = rub;
            Kopeeks = kop;
        }

        public override string ToString()
        {
            return $"{Rubles} руб. {Kopeeks} коп.\n";
        }

        public void AddKopeeks(uint userKopeeks)
        {
            uint sumKopeeks = Rubles * 100 + Kopeeks + userKopeeks;
            Rubles = (uint)(sumKopeeks / 100);
            Kopeeks = (byte)(sumKopeeks % 100);
        }
    }
}

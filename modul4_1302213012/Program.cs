// See https://aka.ms/new-console-template for more information
internal class Program
{
    public enum buah
    {
        Apel,
        Aprikot,
        Alpukat,
        Pisang,
        Paprika,
        Blackberry,
        Ceri,
        Kelapa,
        Jagung
    }

    public enum stateKarakter
    {
        Jongkok,
        Berdiri, 
        Terbang,
        Tengkurap
    }

    public enum triggerKarakter
    {
        TombolW, TombolX, TombolS
    }

    public class KodeBuah
    {
        public static string getKodeBuah(buah inBuah)
        {
            string[] outKodeBuah = { "A00", "B00", "C00", "D00", "E00", "K00", "L00", "M00", "N00", "O00" };
            int inInt = (int)inBuah;
            return outKodeBuah[inInt];
        }
    }

    public class PosisiKarakterGame
    {
        public stateKarakter currentState = stateKarakter.Berdiri;
        
        public class move
        {
            public stateKarakter awal;
            public stateKarakter akhir;
            public triggerKarakter trigger;

            public move(stateKarakter awal, stateKarakter akhir, triggerKarakter trigger)
            {
                this.awal = awal;
                this.akhir = akhir;
                this.trigger = trigger;
            }
        }

        move[] animation = new move[]
        {
            new move(stateKarakter.Jongkok, stateKarakter.Tengkurap, triggerKarakter.TombolS),
            new move(stateKarakter.Tengkurap, stateKarakter.Jongkok, triggerKarakter.TombolW),
            new move(stateKarakter.Jongkok, stateKarakter.Berdiri, triggerKarakter.TombolW),
            new move(stateKarakter.Berdiri, stateKarakter.Jongkok, triggerKarakter.TombolS),
            new move(stateKarakter.Berdiri, stateKarakter.Terbang, triggerKarakter.TombolW),
            new move(stateKarakter.Terbang, stateKarakter.Berdiri, triggerKarakter.TombolS),
            new move(stateKarakter.Terbang, stateKarakter.Jongkok, triggerKarakter.TombolX)
        };

        private stateKarakter stateBerikutnya(stateKarakter awal, triggerKarakter trigger)
        {
            stateKarakter akhir = awal;
            for(int i = 0; i < animation.Length; i++)
            {
                move ubah = animation[i];
                if(awal == ubah.awal && trigger == ubah.trigger)
                {
                    akhir = ubah.akhir;
                }
            }
            return akhir;
        }

        public void triggerActive(triggerKarakter trigger)
        {
            currentState = stateBerikutnya(currentState, trigger);
            Console.WriteLine("State sekarang: " + currentState);
            if(trigger == triggerKarakter.TombolS)
            {
                Console.WriteLine("Tombol arah bawah ditekan");
            }else if(trigger == triggerKarakter.TombolW)
            {
                Console.WriteLine("Tombol arah atas ditekan");
            }
        }
    }

    private static void Main(string[] args)
    {
        buah enBuah = buah.Alpukat;
        string codeBuah = KodeBuah.getKodeBuah(enBuah);
        Console.WriteLine("Buah " + enBuah + " memiliki kode " + codeBuah);
        Console.WriteLine();

        PosisiKarakterGame karakter = new PosisiKarakterGame();
        karakter.triggerActive(triggerKarakter.TombolS);
        karakter.triggerActive(triggerKarakter.TombolW);
    }
}

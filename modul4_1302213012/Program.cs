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

    public class KodeBuah
    {
        public static string getKodeBuah(buah inBuah)
        {
            string[] outKodeBuah = { "A00", "B00", "C00", "D00", "E00", "K00", "L00", "M00", "N00", "O00" };
            int inInt = (int)inBuah;
            return outKodeBuah[inInt];
        }
    }

    private static void Main(string[] args)
    {
        KodeBuah Buah = new KodeBuah();
        buah enBuah = buah.Alpukat;
        string codeBuah = KodeBuah.getKodeBuah(enBuah);
        Console.WriteLine("Buah " + enBuah + " memiliki kode " + codeBuah);
    }
}

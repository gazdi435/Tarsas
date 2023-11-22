namespace Tarsas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> dobasok = new List<int>();
            File.ReadAllLines("dobasok.txt").ToList().ForEach(x=> x.Split(" ").ToList().ForEach(y=> dobasok.Add(Convert.ToInt16(y))));

            List<string> osvenyek = new List<string>();
            File.ReadAllLines("osvenyek.txt").ToList().ForEach(x => osvenyek.Add(x));

            //1
            Console.WriteLine($"Összes ösvény: {osvenyek.Count}");

            //2
            Console.WriteLine($"Összes dobás: {dobasok.Count}");

            //3
            Console.WriteLine($"A legtöbb mezőből álló ösvény: {osvenyek.FindIndex(x=>x.Length== osvenyek.Max(x => x.Length))+1}. ösvény. Mezők száma: {osvenyek.Max(x=> x.Length)}");

            //4
            Console.Write("Kérem adja meg az ösvény sorszámát, majd SPACE-el leválasztva a játékot játszók számát: ");
            int osveny = Convert.ToInt32(Console.ReadLine());
            int jatekosok;

            do
            {
                jatekosok = Convert.ToInt32(Console.ReadLine());
            } while (jatekosok<2 || jatekosok > 5);

            //5
            Console.Write("Az ösvény tartalmaz: ");
            if (osvenyek[osveny-1].Contains("M"))
            {
                Console.Write($"M: {osvenyek[osveny-1].ToList().Count(x=> x == 'M')}; ");
            }
            if (osvenyek[osveny - 1].Contains("E"))
            {
                Console.Write($"E: {osvenyek[osveny - 1].Count(x => x == 'E')}; ");
            }
            if (osvenyek[osveny - 1].Contains("V"))
            {
                Console.Write($"V: {osvenyek[osveny - 1].Count(x => x == 'V')}; ");
            }
            Console.WriteLine();

            //6
            int szamlalo = 1;
            File.Delete("kulonleges.txt");
            foreach (var mezo in osvenyek[osveny-1])
            {
                if (mezo=='E' || mezo=='V')
                {
                    File.AppendAllText("kulonleges.txt", mezo+"\t"+szamlalo+"\n");
                }
                szamlalo++;
            }

            //7
            List<List<int>> list = new List<List<int>>();
            List<int> charList = new List<int>();

            for (int i = 1; i < jatekosok+1 ; i++)
            {
                charList.Clear();
                for (int szam = 1; szam <= Convert.ToInt16(Math.Floor(Convert.ToDouble(dobasok.Count / jatekosok))); szam++)
                {
                    charList.Add(dobasok[i*szam-1]);
                    File.AppendAllText("yes.txt", Convert.ToString(dobasok[i * szam ]));
                }
                list.Add(charList);
                File.AppendAllText("yes.txt", "\n");
            }
        }
    }
}
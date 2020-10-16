namespace balkezesek
{
    internal class Jatekos
    {
        public string nev { get; private set; }
        public string elsorepalyan { get; private set; }
        public string utoljarapalyan { get; private set; }
        public int suly { get; private set; }
        public int magassag { get; private set; }

        public Jatekos(string nev, string elsorepalyan, string utoljarapalyan, int suly, int magassag)
        {
            this.nev = nev;
            this.elsorepalyan = elsorepalyan;
            this.utoljarapalyan = utoljarapalyan;
            this.suly = suly;
            this.magassag = magassag;
        }
    }
}
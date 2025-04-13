using System;

class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    public override double HitungGaji()
    {
        return GajiPokok + 500000;
    }
}

class KaryawanKontrak : Karyawan
{
    public override double HitungGaji()
    {
        return GajiPokok - 200000;
    }
}

class KaryawanMagang : Karyawan
{
    public override double HitungGaji()
    {
        return GajiPokok;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Masukkan jenis karyawan (Tetap/Kontrak/Magang): ");
        string jenis = Console.ReadLine().ToLower();

        Console.Write("Nama: ");
        string nama = Console.ReadLine();

        Console.Write("ID: ");
        string id = Console.ReadLine();

        Console.Write("Gaji Pokok: ");
        double gajiPokok = Convert.ToDouble(Console.ReadLine());

        Karyawan karyawan;

        switch (jenis)
        {
            case "tetap":
                karyawan = new KaryawanTetap();
                break;
            case "kontrak":
                karyawan = new KaryawanKontrak();
                break;
            case "magang":
                karyawan = new KaryawanMagang();
                break;
            default:
                Console.WriteLine("Jenis karyawan tidak valid.");
                return;
        }

        karyawan.Nama = nama;
        karyawan.ID = id;
        karyawan.GajiPokok = gajiPokok;

        double gajiAkhir = karyawan.HitungGaji();

        Console.WriteLine($"\nGaji Akhir {karyawan.Nama} ({jenis.ToUpper()}) dengan ID {karyawan.ID} adalah: Rp{gajiAkhir}");
    }
}

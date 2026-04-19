public class Peminjaman
{
    public int Id_Pinjam { get; set; }
    public int Id_Anggota { get; set; }
    public int Id_Buku { get; set; }
    public DateTime Tanggal_Pinjam { get; set; }
    public DateTime Tanggal_Kembali { get; set; }
}
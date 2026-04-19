using Microsoft.AspNetCore.Mvc;
using Dapper;

[ApiController]
[Route("api/[controller]")]
public class PeminjamanController : ControllerBase
{
    private readonly DbConnection _db;

    public PeminjamanController(DbConnection db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        using var conn = _db.CreateConnection();

        var data = conn.Query(@"
            SELECT p.*, a.nama, b.judul
            FROM peminjaman p
            JOIN anggota a ON p.id_anggota = a.id_anggota
            JOIN buku b ON p.id_buku = b.id_buku
        ");

        return Ok(new { status = "success", data });
    }

    [HttpPost]
    public IActionResult Create(Peminjaman p)
    {
        using var conn = _db.CreateConnection();

        string query = @"INSERT INTO peminjaman
            (id_anggota, id_buku, tanggal_pinjam, tanggal_kembali)
            VALUES(@Id_Anggota, @Id_Buku, @Tanggal_Pinjam, @Tanggal_Kembali)";

        conn.Execute(query, p);

        return Ok(new { status = "success", message = "Peminjaman berhasil" });
    }
}
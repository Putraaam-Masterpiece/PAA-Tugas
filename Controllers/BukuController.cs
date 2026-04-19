using Microsoft.AspNetCore.Mvc;
using Dapper;

[ApiController]
[Route("api/[controller]")]
public class BukuController : ControllerBase
{
    private readonly DbConnection _db;

    public BukuController(DbConnection db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        using var conn = _db.CreateConnection();
        var data = conn.Query("SELECT * FROM buku");

        return Ok(new { status = "success", data });
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        using var conn = _db.CreateConnection();
        var data = conn.QueryFirstOrDefault("SELECT * FROM buku WHERE id_buku=@Id", new { Id = id });

        if (data == null)
            return NotFound(new { status = "error", message = "Data tidak ditemukan" });

        return Ok(new { status = "success", data });
    }

    [HttpPost]
    public IActionResult Create(Buku buku)
    {
        using var conn = _db.CreateConnection();

        string query = "INSERT INTO buku(judul, penulis, stok) VALUES(@Judul, @Penulis, @Stok)";
        conn.Execute(query, buku);

        return Ok(new { status = "success", message = "Data berhasil ditambahkan" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Buku buku)
    {
        using var conn = _db.CreateConnection();

        string query = "UPDATE buku SET judul=@Judul, penulis=@Penulis, stok=@Stok WHERE id_buku=@Id";
        conn.Execute(query, new { buku.Judul, buku.Penulis, buku.Stok, Id = id });

        return Ok(new { status = "success", message = "Data berhasil diupdate" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        using var conn = _db.CreateConnection();

        conn.Execute("DELETE FROM buku WHERE id_buku=@Id", new { Id = id });

        return Ok(new { status = "success", message = "Data berhasil dihapus" });
    }
}
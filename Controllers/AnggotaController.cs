using Microsoft.AspNetCore.Mvc;
using Dapper;

[ApiController]
[Route("api/[controller]")]
public class AnggotaController : ControllerBase
{
    private readonly DbConnection _db;

    public AnggotaController(DbConnection db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        using var conn = _db.CreateConnection();
        var data = conn.Query("SELECT * FROM anggota");

        return Ok(new { status = "success", data });
    }

    [HttpPost]
    public IActionResult Create(Anggota anggota)
    {
        using var conn = _db.CreateConnection();

        string query = "INSERT INTO anggota(nama, email) VALUES(@Nama, @Email)";
        conn.Execute(query, anggota);

        return Ok(new { status = "success", message = "Data anggota ditambahkan" });
    }
}
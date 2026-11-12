using Microsoft.AspNetCore.Mvc;

namespace MusicRecords.Api.Controllers;

[ApiController]
[Route("api/records")]
public class RecordsController(MusicRecordRepository repository) : ControllerBase
{
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IReadOnlyList<MusicRecord>), StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<MusicRecord>> GetAll(
        [FromQuery] string? title = null, [FromQuery] string? artist = null)
    {
        return Ok(repository.GetAll(title, artist));
    }
}

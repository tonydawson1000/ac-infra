using Ac.Infra.Service.Business.DataCentres;
using Ac.Infra.Service.Models.DataCentres;
using Ac.Infra.Service.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace Ac.Infra.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataCentresController : ControllerBase
    {
        private readonly ILogger<DataCentresController> _logger;
        private readonly IDataCentreService _dataCentreService;

        public DataCentresController(
            ILogger<DataCentresController> logger,
            IDataCentreService dataCentreService)
        {
            _logger = logger;
            _dataCentreService = dataCentreService;
        }

        [HttpGet(Name = "GetDataCentres")]
        [ProducesResponseType(typeof(IEnumerable<DataCentreModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<DataCentreModel>>> GetDataCentres(
            [FromQuery] DataCentreResourceParameters dataCentreResourceParameters)
        {
            _logger.LogDebug(
                LoggingEvents.eidInfoDataCentreControllerGet,
                "Getting DataCentres in API : '{dataCentreResourceParameters}'",
                dataCentreResourceParameters);

            var dataCentres = await _dataCentreService.GetDataCentres(dataCentreResourceParameters);

            if (dataCentres == null || !dataCentres.Any())
            {
                _logger.LogWarning(
                    LoggingEvents.eidWarningDataCentreControllerGetNotFound,
                    "No DataCentres Found '{dataCentreResourceParameters}'",
                    dataCentreResourceParameters);

                return NotFound();
            }

            return Ok(dataCentres);
        }

        [HttpGet("{id}", Name = "GetDataCentreById")]
        [ProducesResponseType(typeof(DataCentreModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DataCentreModel>> GetDataCentreById(Guid id)
        {
            _logger.LogDebug(
                LoggingEvents.eidInfoDataCentreControllerGetById,
                "Getting DataCentre in API by '{id}'", id);

            var dataCentre = await _dataCentreService.GetDataCentreById(id);

            if (dataCentre == null)
            {
                _logger.LogWarning(
                    LoggingEvents.eidWarningDataCentreControllerGetByIdNotFound,
                    "No DataCentre Found with id = '{id}'", id);

                return NotFound();
            }

            return Ok(dataCentre);
        }
    }
}
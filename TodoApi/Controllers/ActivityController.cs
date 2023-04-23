using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TodoApi.Interfaces;
using TodoApi.Models;
using TodoApi.Repository;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("Api/V1/[controller]")]
    public class ActivityController : Controller
    {
       private readonly IActivityRepository _activityRepository;
        public ActivityController(IActivityRepository ActivityRepository)
        {
            _activityRepository = ActivityRepository;
        }

        [HttpGet, Route("Get-All")]
        public async Task<IActionResult> GetAll()
        {
            var activitys = await _activityRepository.GetAll();
            return Ok(activitys);
        }

        [HttpPut, Route("Update")]
        public async Task<IActionResult> Update([FromBody] ActivityModel activity)
        {

            if (activity != null)
            {
                    _activityRepository.Update(activity);
                    return Ok("Atualizado com sucesso");            
            }else
            {
                return BadRequest("Tarefa não informada");
            }
        }

        [HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string activityId)
        {
            if (activityId != null)
            {
                _activityRepository.Delete(activityId);
                return Ok("Deletado com sucesso");
            }
            else
            {
                return BadRequest("Tarefa não informada");
            }
        }

        [HttpPost, Route("Add")]
        public async Task<IActionResult> Add([FromBody] ActivityModel activity)
        {
            if (activity != null)
            {
                _activityRepository.Add(activity);
                return Ok("Tarefa inserida com sucesso");
            }
            else
            {
                return BadRequest("Tarefa não informada");
            }
        }
    }

}

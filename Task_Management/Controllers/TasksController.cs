using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management.Data;
using Task_Management.Models;
using Task_Management.Models.Dto;

namespace Task_Management.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _db;
        private  ResponceDto _responceDto;
        public TasksController(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _responceDto = new ResponceDto();
        }

        [HttpGet]
        public ResponceDto Get() {

            try
            {
               IEnumerable<Tasks_management> tasks = _db.Tasks.ToList();    
                _responceDto.Result = tasks;
            }
            catch(Exception ex)
            {
              _responceDto.Message = ex.Message;
              _responceDto.IsSuccess=false;

            }
            return _responceDto;
        }

        [HttpPost]
        public ResponceDto Post([FromBody] TasksDto tasks)
        {
            try
            {
                Tasks_management tasks_Management = new Tasks_management()
                {
                    Id=tasks.Id,
                    dateTime=tasks.dateTime,
                    status=tasks.Status,
                    category=tasks.category,
                    title=tasks.title,
                    quesstion1=tasks.quesstion1,
                    quesstion2=tasks.quesstion2,
                    quesstion3 = tasks.quesstion3,
                    quesstion4 = tasks.quesstion4,
                    RightAnswer=tasks.RightAnswer,
                };
                _db.Tasks.Add(tasks_Management);
                _db.SaveChanges();
                _responceDto.Result = tasks_Management;
            }
            catch (Exception ex)
            {
                _responceDto.Message=ex.Message;
                _responceDto.IsSuccess=false;
            }
            return _responceDto;
        }

        [HttpPut]
        public object Put([FromBody] TasksDto tasks)
        {
            try
            {
                Tasks_management tasks_Management = new Tasks_management()
                { 
                   Id= tasks.Id,
                   dateTime=tasks.dateTime,
                   category=tasks.category,
                   status=tasks.Status,
                   title=tasks.title,
                   quesstion1=tasks.quesstion1,
                   quesstion2=tasks.quesstion2,
                   quesstion3=tasks.quesstion3,
                   quesstion4=tasks.RightAnswer,
                   RightAnswer=tasks.RightAnswer,
                };
                _db.Tasks.Update(tasks_Management);
                _db.SaveChanges();
                _responceDto.Result=tasks_Management;
            }
            catch(Exception ex)
            {
                _responceDto.Result=ex.Message;
                _responceDto.IsSuccess=false;
            }
            return _responceDto;

        }

        [HttpDelete]
        [Route("{id:int}")]
        public object Delete(int id)
        {
            try
            {
                Tasks_management task =_db.Tasks.First(x=>x.Id==id);
                _db.Tasks.Remove(task);
                _db.SaveChanges();
                _responceDto.Message="successful";
            }
            catch(Exception ex)
            {
                _responceDto.Result = ex.Message;
                _responceDto.IsSuccess=false;
            }
            return _responceDto;
        }
    }
}

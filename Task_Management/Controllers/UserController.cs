using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_Management.Data;
using Task_Management.Models;
using Task_Management.Models.Dto;

namespace Task_Management.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponceDto _responceDto;
        public UserController(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _responceDto = new ResponceDto();
        }

        [HttpGet]
          public ResponceDto Get()
        {
            try
            {
                IEnumerable<UserAnswer> answer = _db.UserAnswer.ToList();
                _responceDto.Result = answer;
            }
            catch (Exception ex)
            {
                _responceDto.Message= ex.Message;
                _responceDto.IsSuccess= false;
            }
            return _responceDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponceDto Get(int id)
        {
            try
            {
                UserAnswer userAnswer = _db.UserAnswer.First(x => x.answerId == id);
                _responceDto.Result = userAnswer;
            }
            catch (Exception ex)
            {
                _responceDto.Message = ex.Message;
                _responceDto.IsSuccess = false;
            }
            return _responceDto;
        }


        [HttpPost]
        public object Post([FromBody] UserDto answer)
        {
            try
            {
                UserAnswer userAnswer = new UserAnswer()
                {
                    answerId = answer.answerId,
                    role = answer.role,
                };
                _db.UserAnswer.Add(userAnswer);
                _db.SaveChanges();
                _responceDto.Result = userAnswer;
            }
            catch(Exception ex) {
             _responceDto.Message= ex.Message;
                _responceDto.IsSuccess= false;
            }
            return _responceDto;
        }
    }
}

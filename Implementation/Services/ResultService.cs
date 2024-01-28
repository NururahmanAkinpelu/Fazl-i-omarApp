using Backend.Dto;
using Backend.Entities;
using Backend.Interface.Services;
using BackEnd.Interface.Repositories;

namespace Backend.Services
{
    public class ResultService : IResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ResultService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<ResultDto>> Create(ResultDto resultDto, Guid studentId, Guid subjectId, Guid levelId)
        {
            var response = new BaseResponse<ResultDto>();

            var selectSession = await _unitOfWork.Session.Get(s => s.CurrentSession == true);
            var Subject = await _unitOfWork.Subject.GetAsync(subjectId);
            var Level = await _unitOfWork.Level.GetAsync(levelId);
            var student = await _unitOfWork.Student.GetAsync(studentId);
            var checkResult =  await _unitOfWork.Result
                .ExistsAsync(r => r.SessionId == selectSession.Id && r.StudentId == studentId && 
                             r.SubjectId == Subject.Id && r.LevelId == Level.Id);
            
            if (selectSession == null)
            {
                response.Message = "No session is currently set on system. Please try again later";
                return response;
            }

            if (checkResult)
            { 
                response.Message = "Result already added";
                return response;
            }

            var result = new Result
            {
                StudentId = studentId,
                Student = student,
                SessionId = selectSession.Id, 
                Session = selectSession,
                SubjectId = Subject.Id,
                Subject = Subject,
                LevelId = Level.Id,
                Level = Level,
                ContinuousAssessment = resultDto.ContinuousAssessment,
                ExamScore = resultDto.ExamScore,
                TotalScore = resultDto.TotalScore,
                Remark = resultDto.Remark
            };

           await _unitOfWork.Result.Register(result);
           response.Message = "Success";
           response.Status = true;
           return response;
        }

        public async Task<BaseResponse<ResultDto>> Delete(Guid resultId)
        {
            var response = new BaseResponse<ResultDto>();
            var result = await _unitOfWork.Result.Get(s => s.Id == resultId);

            if (result is null)
            {
                response.Message = "result not found";
                return response;
            }

            if (result.IsDeleted == true)
            {
                response.Message = "Result already deleted";
                return response;
            }

            result.IsDeleted = true;
            await _unitOfWork.Result.Update(result);
            response.Message = "Deleted Successfully";
            response.Status = true;
            return response;;
        }

        public async Task<BaseResponse<ResultDto>> Get(Guid id)
        {
            var response = new BaseResponse<ResultDto>();
            var result = await _unitOfWork.Result.Get(t => t.Id == id);

            if (result == null)
            {
                response.Message = "Result not found";
                return response;
            }

            var resultDto = new ResultDto
            {
                StudentName = $"{result.Student.FirstName} {result.Student.LastName}",
                SubjectName = result.Subject.Name,
                Level = result.Level.LevelName,
                ContinuousAssessment = result.ContinuousAssessment,
                ExamScore = result.ExamScore,
                TotalScore = result.TotalScore
            };

            response.Data = resultDto;
            response.Message = "Success";
            response.Status = true;
            return response;
        }

        public Task<BaseResponse<IEnumerable<ResultDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<ResultDto>> Update(ResultDto resultDto, Guid resultId)
        {
            throw new NotImplementedException();
        }
    }
}
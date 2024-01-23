using Backend.Dto;
using Backend.Entities;
using Backend.Interface.Services;
using BackEnd.Interface.Repositories;

namespace Backend.Implementation.Services
{
    public class GradeService : IGradeService
    {
        public readonly IUnitOfWork _unitOfWork;

        public GradeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse<GradeDto>> Create(GradeDto gradeDto)
        {
            var response = new BaseResponse<GradeDto>();
            var checkGrade = await _unitOfWork.Grade.ExistsAsync(g => g.GradeName == gradeDto.Name);

            if (checkGrade)
            {
                response.Message = "Class already exist";
                return response;
            }

            var grade =  new Grade{
                GradeName = gradeDto.Name
            };

            await _unitOfWork.Grade.Register(grade);
            response.Message = "Success";
            response.Status = true;
            return response;
        }

        public Task<BaseResponse<GradeDto>> Delete(Guid gradeId)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<GradeDto>> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<IEnumerable<GradeDto>>> GetAll()
        {
            var response = new BaseResponse<IEnumerable<GradeDto>>();
            var Grades = await _unitOfWork.Grade.GetAll();

            if (Grades is null)
            {
                response.Message = "No Grade registered";
                return response;
            }

            var GradeDtos = Grades.Select(g => new GradeDto{
                Id = g.Id,
                Name = g.GradeName,
            }).ToList();

            response.Data = GradeDtos;
            response.Message = "Success";
            response.Status = true;
            return response;
        }

        public Task<BaseResponse<GradeDto>> Update(GradeDto gradeDto, Guid gradeId)
        {
            throw new NotImplementedException();
        }
    }
}
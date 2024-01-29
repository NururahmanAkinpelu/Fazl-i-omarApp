using Backend.Dto;
using Backend.Entities;

namespace Backend.Interface.Services
{
    public interface IResultService
    {
        Task<BaseResponse<ResultDto>> Create(ResultDto resultDto, Guid studentId, Guid subjectId, Guid levelId);
        Task<BaseResponse<ResultDto>> Update(ResultDto resultDto, Guid resultId);
        Task<BaseResponse<ResultDto>> Get(Guid id);
        Task<BaseResponse<ResultDto>> Delete(Guid resultId);
        Task<BaseResponse<IEnumerable<ResultDto>>> GetAll(Guid studentId);
    }
}
using Backend.Dto;

namespace Backend.Interface.Services
{
    public interface IGradeService
    {
        Task<BaseResponse<GradeDto>> Create(GradeDto gradeDto);
        Task<BaseResponse<GradeDto>> Update(GradeDto gradeDto, Guid gradeId);
        Task<BaseResponse<GradeDto>> Get(Guid id);
        Task<BaseResponse<GradeDto>> Delete(Guid gradeId);
        Task<BaseResponse<IEnumerable<GradeDto>>> GetAll();
    }
}
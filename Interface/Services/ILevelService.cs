using Backend.Dto;

namespace Backend.Interface.Services
{
    public interface ILevelService
    {
        Task<BaseResponse<LevelDto>> Create(LevelDto levelDto);
        Task<BaseResponse<LevelDto>> Update(LevelDto levelDto, Guid levelId);
        Task<BaseResponse<LevelDto>> Delete(Guid levelId);
        Task<BaseResponse<IEnumerable<LevelDto>>> GetAll();
    }
}

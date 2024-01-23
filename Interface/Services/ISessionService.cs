using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dto;
using Backend.Entities;

namespace Backend.Interface.Services
{
    public interface ISessionService
    {
         Task<BaseResponse<SessionDto>> Create(SessionDto sessionDto);
        Task<BaseResponse<SessionDto>> Update(SessionDto sessionDto, Guid sessionId);
        Task<BaseResponse<SessionDto>> Delete(Guid sessionId);
        Task<BaseResponse<IEnumerable<SessionDto>>> GetAll();
    }
}
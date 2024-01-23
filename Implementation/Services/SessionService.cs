using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dto;
using Backend.Entities;
using Backend.Interface.Services;
using BackEnd.Interface.Repositories;

namespace Backend.Services
{
    public class SessionService : ISessionService
{
    public IUnitOfWork _unitOfWork;
    public SessionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseResponse<SessionDto>> Create(SessionDto sessionDto)
    {
        var response = new BaseResponse<SessionDto>();

        var ifExist = await _unitOfWork.Session.Get(s => s.SessionName == sessionDto.SessionName);
        if (ifExist != null)
        {
            response.Message = "Session already exist";
            return response;
        }

        var session = new Session
        {
            SessionName = sessionDto.SessionName,
            StartDate = sessionDto.StartDate,
            EndDate = sessionDto.EndDate,
            CurrentSession = true
        };

       await _unitOfWork.Session.Register(session);
       response.Message = "Success";
       response.Status = true;
       return response;
    }

    public Task<BaseResponse<SessionDto>> Delete(Guid sessionId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<IEnumerable<SessionDto>>> GetAll()
    {
        var response = new BaseResponse<IEnumerable<SessionDto>>();
        var sessions = await _unitOfWork.Session.GetAll();

        if (sessions is null)
        {
            response.Message = "No session registered";
            return response;
        }

        var sessionDtos = sessions.Select(s => new SessionDto{
            Id = s.Id,
            SessionName = s.SessionName,
            StartDate = s.StartDate,
            EndDate = s.EndDate
        }).ToList();

        response.Data = sessionDtos;
        response.Message = "Success";
        response.Status = true;
        return response;
    }

    public Task<BaseResponse<SessionDto>> Update(SessionDto sessionDto, Guid sessionId)
    {
        throw new NotImplementedException();
    }
}
}
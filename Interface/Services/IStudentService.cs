﻿using Backend.Dto;

namespace Backend.Interface.Services
{
    public interface IStudentService
    {
        Task<BaseResponse<StudentDto>> Register(StudentDto studentDto);
        Task<BaseResponse<StudentDto>> Update(StudentDto studentDto, Guid id);
        Task<BaseResponse<StudentDto>> Delete(Guid id);
        Task<BaseResponse<StudentDto>> Get(Guid id);
        Task<BaseResponse<StudentDto>> Get(string email);
        Task<BaseResponse<StudentDto>> GetByStudentId(string studentId);
        Task<BaseResponse<IEnumerable<StudentDto>>> GetAll();
        Task<BaseResponse<IEnumerable<StudentDto>>> GetAll(Guid levelId);
    }
}

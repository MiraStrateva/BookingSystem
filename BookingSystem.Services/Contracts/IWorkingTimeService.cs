using BookingSystem.Data.Models;
using System;

namespace BookingSystem.Services.Contracts
{
    public interface IWorkingtimeService
    {
        Workingtime GetWorkingtimeById(Guid id);

        Workingtime GetWorkingtimeByCompanyId(Guid companyId);
    }
}

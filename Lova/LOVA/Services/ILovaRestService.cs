using LOVA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LOVA.Services
{
    public interface ILovaRestService
    {
        Task<List<IssueReport>> GetGetAllIssues();
    }
}

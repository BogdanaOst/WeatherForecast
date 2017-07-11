using DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Managers
{
    public interface IHistoryManager
    {
        List<HistoryDTO> GetAll();
        void Add(HistoryDTO history_dto);
        void Dispose();
    }
}
